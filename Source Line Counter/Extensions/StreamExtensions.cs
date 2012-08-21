#region

using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace SourceLineCounter.Extensions
{
    internal static class StreamExtensions
    {
        public static IEnumerable<string> ReadLines(this Stream stream, Encoding encoding)
        {
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}