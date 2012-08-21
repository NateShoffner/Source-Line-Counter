#region

using System.IO;

#endregion

namespace SourceLineCounter
{
    internal class ProcessedFile : SourceStats
    {
        public ProcessedFile(FileInfo info, LanguageProfile profile, SourceStats stats)
        {
            Info = info;
            Profile = profile;
            Stats = stats;
        }

        public FileInfo Info { get; private set; }
        public LanguageProfile Profile { get; set; }
        public SourceStats Stats { get; private set; }
    }
}