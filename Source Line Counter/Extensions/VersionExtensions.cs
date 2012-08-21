#region

using System;

#endregion

namespace SourceLineCounter.Extensions
{
    internal static class VersionExtensions
    {
        public static Version Trim(this Version version, bool enforceDecimal = true)
        {
            var str = version.ToString();

            while (str.EndsWith("0") || str.EndsWith("."))
            {
                str = str.Remove(str.Length - 1, 1);
            }

            if (enforceDecimal && !str.Contains("."))
            {
                str = string.Format("{0}.0", str);
            }

            return new Version(str);
        }
    }
}