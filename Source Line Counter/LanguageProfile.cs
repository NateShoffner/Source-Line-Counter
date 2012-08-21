namespace SourceLineCounter
{
    internal class LanguageProfile
    {
        public long? ID { get; set; }

        public string Name { get; set; }
        public string[] Extensions { get; set; }
        public LanguageCommentIndicator[] CommentIndicators { get; set; }
        public string[] Preprocessors { get; set; }
        public bool AllowInlineComments { get; set; }
        public bool AllowInterspersedComments { get; set; }
    }
}