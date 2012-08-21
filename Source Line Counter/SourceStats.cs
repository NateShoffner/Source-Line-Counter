namespace SourceLineCounter
{
    internal class SourceStats
    {
        public int TotalLines { get; set; }
        public int CommentedLines { get; set; }
        public int PreprocessorLines { get; set; }
        public int EmptyLines { get; set; }
        public int CodeLines { get; set; }

        public void AddStats(SourceStats stats)
        {
            CommentedLines += stats.CommentedLines;
            EmptyLines += stats.EmptyLines;
            PreprocessorLines += stats.PreprocessorLines;
            CodeLines += stats.CodeLines;
            TotalLines += stats.TotalLines;
        }
    }
}