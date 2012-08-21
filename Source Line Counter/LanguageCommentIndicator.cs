namespace SourceLineCounter
{
    internal class LanguageCommentIndicator
    {
        public LanguageCommentIndicator(string startIndicator)
        {
            StartIndicator = startIndicator;
        }

        public LanguageCommentIndicator(string startIndicator, string endIndicator, bool multiline) : this(startIndicator)
        {
            EndIndicator = endIndicator;
            Multiline = multiline;
        }

        public string StartIndicator { get; private set; }
        public string EndIndicator { get; private set; }
        public bool Multiline { get; private set; }

        public bool HasEndIndicator
        {
            get { return EndIndicator != null; }
        }
    }
}