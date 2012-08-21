#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SourceLineCounter;
using SourceLineCounter.Extensions;

#endregion

namespace SourceLineCounter
{
    internal class CounterProgressEventArgs : EventArgs
    {
        public CounterProgressEventArgs(string file, int percentage)
        {
            PercentageCompleted = percentage;
            CurrentFile = file;
        }

        public int PercentageCompleted { get; private set; }
        public string CurrentFile { get; private set; }
    }

    internal class CounterCompletedEventArgs : EventArgs
    {
        public CounterCompletedEventArgs(bool cancelled)
        {
            Cancelled = cancelled;
        }

        public bool Cancelled { get; private set; }
    }
}

internal class PathOption
{
    public PathOption(string path, SearchOption option)
    {
        Path = path;
        Option = option;
    }

    public string Path { get; private set; }
    public SearchOption Option { get; private set; }
}

internal class SourceCounter
{
    #region Fields

    private readonly IEnumerable<PathOption> _pathOptions;
    private readonly Dictionary<LanguageProfile, SourceStats> _profileStats = new Dictionary<LanguageProfile, SourceStats>();
    private readonly Dictionary<string, ProcessedFile> _sourceFiles = new Dictionary<string, ProcessedFile>();
    private CancellationTokenSource _cancellationTokenSource;

    #endregion

    #region Contructors

    public SourceCounter(IEnumerable<LanguageProfile> profiles, IEnumerable<PathOption> paths)
    {
        _pathOptions = paths;
        _profiles.AddRange(profiles);
    }

    #endregion

    #region Properties

    private readonly List<LanguageProfile> _profiles = new List<LanguageProfile>();

    public ReadOnlyCollection<LanguageProfile> Profiles
    {
        get { return _profiles.AsReadOnly(); }
    }

    public SourceStats Stats { get; private set; }

    public int TotalFiles { get; private set; }

    public long TotalBytes { get; private set; }

    #endregion

    #region Events

    public event EventHandler<CounterProgressEventArgs> ProgressChanged;
    public event EventHandler<CounterCompletedEventArgs> Completed;
    public event EventHandler BuildingFileList;

    #endregion

    #region Public Methods

    public void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = _cancellationTokenSource.Token;
        var progressReporter = new ProgressReporter();

        Stats = new SourceStats();
        _wasCancelled = false;
        _profileStats.Clear();
        _sourceFiles.Clear();

        var task = Task.Factory.StartNew(() =>
        {
            progressReporter.ReportProgress(() =>
            {
                if (BuildingFileList != null)
                    BuildingFileList(this, EventArgs.Empty);
            });

            var files = BuildFileList(progressReporter, cancellationToken);

            var count = 0;

            foreach (var file in files)
            {
                ProcessedFile processedFile;

                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    processedFile = ProcessFile(file.Key, file.Value);
                }
                catch (OperationCanceledException)
                {
                    _wasCancelled = true;
                    return;
                }

                _sourceFiles.Add(file.Key, processedFile);

                Stats.AddStats(processedFile.Stats);

                if (!_profileStats.ContainsKey(processedFile.Profile))
                    _profileStats[processedFile.Profile] = new SourceStats();
                _profileStats[processedFile.Profile].AddStats(processedFile.Stats);

                TotalFiles++;
                TotalBytes += processedFile.Info.Length;

                count++;

                progressReporter.ReportProgress(() =>
                {
                    if (ProgressChanged != null)
                        ProgressChanged(this, new CounterProgressEventArgs(file.Key, count*100/files.Count));
                });
            }
        }, cancellationToken);

        progressReporter.RegisterContinuation(task, () =>
        {
            if (Completed != null)
                Completed(this, new CounterCompletedEventArgs(_wasCancelled));
        });
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }

    public SourceStats GetProfileStats(LanguageProfile profile)
    {
        SourceStats stats;
        _profileStats.TryGetValue(profile, out stats);
        return stats;
    }

    #endregion

    private bool _wasCancelled;

    private Dictionary<string, LanguageProfile> BuildFileList(ProgressReporter progressReporter, CancellationToken cancellationToken)
    {
        var files = new Dictionary<string, LanguageProfile>();

        //build extension-profile map
        var profileExtensions = new Dictionary<string, LanguageProfile>();
        foreach (var profile in Profiles)
        {
            foreach (var ext in profile.Extensions.Where(ext => !profileExtensions.ContainsKey(ext.ToUpper())))
            {
                profileExtensions.Add(ext.ToUpper(), profile);
            }
        }

        Func<string, LanguageProfile> getMappedProfile = delegate(string path)
        {
            var ext = Path.GetExtension(path);
            LanguageProfile profile = null;

            if (ext != null)
            {
                profileExtensions.TryGetValue(ext.ToUpper(), out profile);
            }

            return profile;
        };

        Func<string, bool> ignoreFile = delegate(string path)
        {
            var attr = File.GetAttributes(path);

            return attr.HasFlag(FileAttributes.Hidden) || attr.HasFlag(FileAttributes.System);
        };

        foreach (var path in _pathOptions)
        {
            if (!Directory.Exists(path.Path) && !File.Exists(path.Path))
                continue;

            var attr = File.GetAttributes(path.Path);


            if (attr.HasFlag(FileAttributes.Directory))
            {
                foreach (var file in SafeFileEnumerator.EnumerateFiles(path.Path, "*.*", path.Option))
                {
                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (ignoreFile(file))
                            continue;

                        var profile = getMappedProfile(file);
                        if (profile != null && !files.ContainsKey(file))
                        {
                            files[file] = profile;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        _wasCancelled = true;
                        //return empty results on cancellation
                        return new Dictionary<string, LanguageProfile>();
                    }
                }
            }

            else
            {
                try
                {
                    if (ignoreFile(path.Path))
                        continue;

                    var profile = getMappedProfile(path.Path);

                    if (profile != null && !files.ContainsKey(path.Path))
                    {
                        files[path.Path] = profile;
                    }
                }

                catch (UnauthorizedAccessException)
                {
                }
            }
        }

        return files;
    }

    public ProcessedFile[] GetProcessedFiles()
    {
        return _sourceFiles.Values.Select(value => (value)).ToArray();
    }

    #region File Processing

    private static ProcessedFile ProcessFile(string fileName, LanguageProfile profile)
    {
        var stats = new SourceStats();

        var fileStream = new FileStream(fileName, FileMode.Open);

        var inMultilineComment = false;

        foreach (var line in fileStream.ReadLines(Encoding.UTF8))
        {
            stats.TotalLines++;

            switch (GetLineType(line, profile, inMultilineComment))
            {
                case LineType.Empty:
                    stats.EmptyLines++;
                    break;
                case LineType.Source:
                    break;
                case LineType.Preprocessor:
                    stats.PreprocessorLines++;
                    break;
                case LineType.MultilineCommentBegin:
                    stats.CommentedLines++;
                    inMultilineComment = true;
                    break;
                case LineType.MultilineCommentEnd:
                case LineType.MultilineCommentInterspersedEnd:
                    stats.CommentedLines++;
                    inMultilineComment = false;
                    break;
                case LineType.MultilineCommentInterspersedBegin:
                    stats.CodeLines++;
                    inMultilineComment = true;
                    break;
                case LineType.MultilineCommentInterspersedEndContinued:
                    stats.CodeLines++;
                    inMultilineComment = false;
                    break;
                case LineType.Comment:
                case LineType.MultilineCommentMiddle:
                case LineType.MultilineCommentInline:
                    stats.CommentedLines++;
                    break;
            }
        }

        fileStream.Close();

        stats.CodeLines = stats.TotalLines - stats.CommentedLines - stats.EmptyLines;

        var file = new ProcessedFile(new FileInfo(fileName), profile, stats);
        return file;
    }

    private static LineType GetLineType(string str, LanguageProfile profile, bool inMultilineComment)
    {
        var line = str.Trim();

        //check for whitespace
        if (!inMultilineComment && line.Length == 0)
        {
            return LineType.Empty;
        }

        if (profile.CommentIndicators.Any(x => x.Multiline)) //todo should probably move this
        {
            if (inMultilineComment)
            {
                //look for end of multiline comment
                foreach (var mci in profile.CommentIndicators)
                {
                    if (mci.HasEndIndicator)
                    {
                        //end of multiline comment
                        if (line.StartsWith(mci.EndIndicator) || line.EndsWith(mci.EndIndicator))
                        {
                            return LineType.MultilineCommentEnd;
                        }

                        //end of interspersed multiline comment
                        if (profile.AllowInterspersedComments && line.Contains(mci.EndIndicator))
                        {
                            //check if there is code after comment
                            return line.EndsWith(mci.EndIndicator)
                                ? LineType.MultilineCommentInterspersedEnd
                                : LineType.MultilineCommentInterspersedEndContinued;
                        }
                    }
                }

                return LineType.MultilineCommentMiddle;
            }

            if (profile.Preprocessors.Any(line.StartsWith))
            {
                return LineType.Preprocessor;
            }

            //check for multiline comment
            foreach (var mci in profile.CommentIndicators)
            {
                //multiline comment start found
                if (line.StartsWith(mci.StartIndicator))
                {
                    // inline multiline comment
                    if (profile.AllowInlineComments && mci.HasEndIndicator && line.EndsWith(mci.EndIndicator) && line.Length > mci.EndIndicator.Length)
                    {
                        return LineType.MultilineCommentInline;
                    }

                    //entering multiline comment
                    return LineType.MultilineCommentBegin;
                }

                // interspersed multiline comment begin
                if (profile.AllowInterspersedComments && line.Contains(mci.StartIndicator))
                {
                    return LineType.MultilineCommentInterspersedBegin;
                }

                break;
            }
        }

        if (!inMultilineComment && profile.CommentIndicators.Any(ci => line.StartsWith(ci.StartIndicator)))
        {
            return LineType.Comment;
        }

        return LineType.Source;
    }

    private enum LineType
    {
        Empty,
        Comment,
        Preprocessor,
        Source,
        MultilineCommentBegin,
        MultilineCommentMiddle,
        MultilineCommentEnd,
        MultilineCommentInline,
        MultilineCommentInterspersedBegin,
        MultilineCommentInterspersedEnd,
        MultilineCommentInterspersedEndContinued
    }

    #endregion
}