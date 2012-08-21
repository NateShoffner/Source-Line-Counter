#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace SourceLineCounter
{
    public static class SafeFileEnumerator
    {
        /// <summary>
        ///     Safely enumerates files, ignoring UnauthorizedAccessException.
        /// </summary>
        public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var files = Enumerable.Empty<string>();

                if (searchOpt == SearchOption.AllDirectories)
                    files = Directory.EnumerateDirectories(path).SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));

                return files.Concat(Directory.EnumerateFiles(path, searchPattern));
            }
            catch (UnauthorizedAccessException)
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}