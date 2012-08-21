#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SourceLineCounter.Extensions;

#endregion

namespace SourceLineCounter.Forms
{
    internal partial class MainForm : Form
    {
        private const string DbName = "profiles.db";
        private readonly Point _chartOffset = new Point(5, 5);
        private readonly Size _chartSize = new Size(130, 130);
        private readonly PieChart _languageChart = new PieChart();
        private readonly ProfileManager _profileManager;
        private readonly PieChart _sourceChart = new PieChart();
        private DateTime _executionStart;
        private Point _lastLanguageGraphPoint = Point.Empty;
        private SourceCounter _sourceCounter;

        public MainForm()
        {
            InitializeComponent();

            Text = string.Format("{0} v{1}", Text, new Version(Application.ProductVersion).Trim());
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

            _profileManager = new ProfileManager(DbName);
            _profileManager.Load();

            PopulateProfiles();

            //image/aspect getters
            olvColFilename.ImageGetter = x =>
            {
                var ext = ((ProcessedFile) x).Info.Extension;
                var icon = ShellInfo.GetShellIcon(ext);

                if (!fileIconList.Images.ContainsKey(ext))
                    fileIconList.Images.Add(ext, icon);

                return ext;
            };
            olvColFilename.AspectGetter = x => ((ProcessedFile) x).Info.Name;
            olvColFiletype.AspectGetter = x =>
            {
                var file = ((ProcessedFile) x);
                var si = new ShellFileInfo(file.Info.Extension);
                var defaultName = string.Format("{0} File", file.Info.Extension.TrimStart(new[] {'.'}).ToUpper());
                var fileType = si.FileType == defaultName ? string.Format("{0} File", file.Profile.Name) : si.FileType;
                return fileType;
            };
            olvColProfile.AspectGetter = x => ((ProcessedFile) x).Profile.Name;
            olvColSize.AspectGetter = x => ((ProcessedFile) x).Info.Length;
            olvColModified.AspectGetter = x => ((ProcessedFile) x).Info.LastWriteTime;
            olvColTotalLines.AspectGetter = x => ((ProcessedFile) x).Stats.TotalLines;
            olvColEmptyLines.AspectGetter = x => ((ProcessedFile) x).Stats.EmptyLines;
            olvColCommentLInes.AspectGetter = x => ((ProcessedFile) x).Stats.CommentedLines;
            olvColCodeLines.AspectGetter = x => ((ProcessedFile) x).Stats.CodeLines;
            olvColDirectory.AspectGetter = x => ((ProcessedFile) x).Info.DirectoryName;
        }

        private void timerExecution_Tick(object sender, EventArgs e)
        {
            var ts = DateTime.Now.Subtract(_executionStart);
            lblExecutionTime.Text = string.Format("{0} mins, {1} secs, {2} ms", ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void PopulateProfiles()
        {
            profileList.Populate(_profileManager, true);
            profileList.Sort();
            profileList_SelectedIndexChanged(null, null);
        }

        private void UpdateStats(bool reset)
        {
            if (reset)
                lblExecutionTime.Text = "N/A";

            lblTotalFiles.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.TotalFiles);
            lblTotalBytes.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.TotalBytes);
            lblTotalLines.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.Stats.TotalLines);
            lblCommentedLines.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.Stats.CommentedLines);
            lblPreprocessorLines.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.Stats.PreprocessorLines);
            lblEmptyLines.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.Stats.EmptyLines);
            lblCodeLines.Text = string.Format("{0:N0}", reset ? 0 : _sourceCounter.Stats.CodeLines);
        }

        private void ManageProfiles(object sender, EventArgs e)
        {
            using (var pd = new ProfilesDialog(_profileManager))
            {
                pd.ShowDialog();

                if (pd.ProfilesModified)
                {
                    PopulateProfiles();
                }
            }
        }

        private void ValidateSettings()
        {
            btnStart.Enabled = txtPaths.Text.Length > 0 && !profileList.NoneSelected;
        }

        private void AddPath(string path)
        {
            if (txtPaths.Text.Length == 0)
                txtPaths.Text = path;
            else
                txtPaths.AppendText(Environment.NewLine + path);

            ValidateSettings();
        }

        private void folderbtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog {ShowNewFolderButton = false, Description = "Select a folder to include."})
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    AddPath(fbd.SelectedPath);
                }
            }
        }

        private void filebtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog {Multiselect = true})
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in ofd.FileNames)
                    {
                        AddPath(file);
                    }
                }
            }
        }

        private void txtPaths_TextChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void profileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSettings();

            selectbtn.Enabled = !profileList.AllSelected;
            unselectbtn.Enabled = !profileList.NoneSelected;
        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            profileList.SelectAll();
        }

        private void unselectbtn_Click(object sender, EventArgs e)
        {
            profileList.UnSelectAll();
        }

        private void openInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedObject != null)
            {
                Process.Start("explorer.exe ", string.Format(@"/select, {0}", ((ProcessedFile) fileListView.SelectedObject).Info.FullName));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _sourceCounter.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var pathOptions = txtPaths.Lines.Select(path => new PathOption(path, chkRecursive.Checked ?
                SearchOption.AllDirectories :
                SearchOption.TopDirectoryOnly)).ToArray();

            _sourceCounter = new SourceCounter(profileList.GetSelectedProfiles().ToArray(), pathOptions);
            _sourceCounter.BuildingFileList += _sourceCounter_BuildingFileList;
            _sourceCounter.ProgressChanged += _sourceCounter_ProgressChanged;
            _sourceCounter.Completed += _sourceCounter_Completed;

            UpdateStats(true);

            _languageChart.Clear();
            ClearLanguageGraph();
            ClearSourceGraph();

            progressBar1.Visible = true;

            btnStop.BringToFront();

            _executionStart = DateTime.Now;
            timerExecution.Start();

            _sourceCounter.Start();
        }

        private void fileListView_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            if (e.Item != null)
                e.MenuStrip = SourceFileMenu;
        }

        private void pbLanguageUsage_MouseMove(object sender, MouseEventArgs e)
        {
            if (pbLanguageUsage.Image == null)
                return;

            if (e.X <= _chartSize.Width + _chartOffset.X && e.Y <= _chartSize.Height + _chartOffset.Y)
            {
                var pixel = ((Bitmap) pbLanguageUsage.Image).GetPixel(e.X, e.Y);

                var profile = _languageGraphItems.Where(item => _languageChart.GetColor(item.Value) == pixel).Select(item => item.Key).FirstOrDefault();

                if (profile != null)
                {
                    if (_lastLanguageGraphPoint != e.Location)
                    {
                        _lastLanguageGraphPoint = e.Location;

                        var stats = _sourceCounter.GetProfileStats(profile);

                        languageUsageTooltip.Show(string.Format("{0}{1}Lines of Code: {2:N0}", profile.Name, Environment.NewLine, stats.CodeLines), pbLanguageUsage, e.X + 20, e.Y + 20);
                    }
                }
            }

            else
            {
                languageUsageTooltip.Hide(this);
            }
        }

        private void pbLanguageUsage_MouseLeave(object sender, EventArgs e)
        {
            languageUsageTooltip.Hide(this);
        }

        private void ResetControls()
        {
            lblprogress.Text = "";
            lblprogress.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            btnStart.BringToFront();
        }

        #region Graphs

        private readonly Dictionary<LanguageProfile, GraphItem> _languageGraphItems = new Dictionary<LanguageProfile, GraphItem>();

        private void lblStatsDisplay_Click(object sender, EventArgs e)
        {
            if (_sourceCounter != null)
            {
                if (pbSourceGraph.Visible)
                {
                    lblStatsDisplay.Text = "View Graph";
                    pbSourceGraph.Visible = false;
                }

                else
                {
                    lblStatsDisplay.Text = "View Stats";
                    pbSourceGraph.Visible = true;
                    pbSourceGraph.BringToFront();
                }
            }
        }

        private void ClearLanguageGraph()
        {
            if (pbLanguageUsage.Image != null)
            {
                pbLanguageUsage.Image.Dispose();
                pbLanguageUsage.Image = null;
            }

            lblNoStats.Visible = true;
        }

        private void DrawLanguageGraph()
        {
            ClearLanguageGraph();

            lblNoStats.Visible = false;

            _languageGraphItems.Clear();

            foreach (var profile in _sourceCounter.Profiles)
            {
                var stats = _sourceCounter.GetProfileStats(profile);

                if (stats != null)
                {
                    var gi = new GraphItem(profile.Name, stats.CodeLines);
                    _languageGraphItems[profile] = gi;
                    _languageChart.Add(gi);
                }
            }

            pbLanguageUsage.Image = _languageChart.Draw(pbLanguageUsage.Size, _chartSize, _chartOffset, _chartOffset, new Size(9, 9), new Font(label1.Font.FontFamily, 7.5f, FontStyle.Regular));
        }

        private void ClearSourceGraph()
        {
            if (pbSourceGraph.Image != null)
            {
                pbSourceGraph.Image.Dispose();
                pbSourceGraph.Image = null;
            }
        }

        private void DrawSourceGraph()
        {
            if (pbSourceGraph.Image != null)
                pbSourceGraph.Image.Dispose();

            _sourceChart.Add(new GraphItem(string.Format("Empty Lines{0}", Environment.NewLine), _sourceCounter.Stats.EmptyLines));
            _sourceChart.Add(new GraphItem(string.Format("Comment Lines{0}", Environment.NewLine), _sourceCounter.Stats.CommentedLines));
            _sourceChart.Add(new GraphItem(string.Format("Preprocessor{0}Lines{0}", Environment.NewLine), _sourceCounter.Stats.PreprocessorLines));
            _sourceChart.Add(new GraphItem(string.Format("Code Lines{0}", Environment.NewLine), _sourceCounter.Stats.CodeLines));

            pbSourceGraph.Image = _sourceChart.Draw(pbSourceGraph.Size, _chartSize, _chartOffset, _chartOffset, new Size(10, 10), new Font(label1.Font.FontFamily, 8, FontStyle.Regular));
        }

        #endregion

        #region SourceCounter Events

        private void _sourceCounter_BuildingFileList(object sender, EventArgs e)
        {
            lblprogress.Visible = true;
            lblprogress.Text = "Building file list...";
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void _sourceCounter_Completed(object sender, CounterCompletedEventArgs e)
        {
            timerExecution.Stop();

            ResetControls();

            if (e.Cancelled)
            {
                MessageBox.Show(this, "The scan has been cancelled.", "Scan Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!e.Cancelled)
            {
                UpdateStats(false);

                fileListView.SetObjects(_sourceCounter.GetProcessedFiles());
                fileListView.BuildList();

                DrawLanguageGraph();
                DrawSourceGraph();
            }
        }

        private void _sourceCounter_ProgressChanged(object sender, CounterProgressEventArgs e)
        {
            if (progressBar1.Style == ProgressBarStyle.Marquee)
                progressBar1.Style = ProgressBarStyle.Continuous;

            lblprogress.Text = e.CurrentFile;
            progressBar1.Value = e.PercentageCompleted;

            UpdateStats(false);
        }

        #endregion
    }
}