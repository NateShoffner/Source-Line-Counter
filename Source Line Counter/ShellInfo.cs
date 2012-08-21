#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

#endregion

namespace SourceLineCounter
{
    internal class ShellFileInfo
    {
        public ShellFileInfo(string extension)
        {
            var shFileInfo = ShellInfo.GetShellInfo(extension);
            FileType = shFileInfo.szTypeName;
            Icon = Icon.FromHandle(shFileInfo.hIcon);
        }

        public Icon Icon { get; private set; }
        public string FileType { get; private set; }
    }

    internal static class ShellInfo
    {
        internal const uint SHGFI_ICON = 0x000000100; // get icon
        internal const uint SHGFI_TYPENAME = 0x000000400; // get type name
        internal const uint SHGFI_SYSICONINDEX = 0x000004000; // get system icon index
        internal const uint SHGFI_SMALLICON = 0x000000001; // get small icon
        internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010; // use passed dwFileAttribute
        internal const uint SHGFI_LARGEICON = 0x000000000; // get large icon

        private static readonly Dictionary<string, SHFILEINFO> shellCache = new Dictionary<string, SHFILEINFO>();
        private static readonly Dictionary<string, Icon> iconCache = new Dictionary<string, Icon>();

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, out SHFILEINFO psfi, int cbFileInfo, uint uFlags);

        public static SHFILEINFO GetShellInfo(string extension)
        {
            var lower = extension.ToLower();

            if (shellCache.ContainsKey(lower))
            {
                return shellCache[lower];
            }

            var rInfo = new SHFILEINFO();
            var ptr = SHGetFileInfo(extension, 0, out rInfo, Marshal.SizeOf(typeof (SHFILEINFO)),
                SHGFI_ICON |
                SHGFI_SMALLICON |
                SHGFI_SYSICONINDEX |
                SHGFI_USEFILEATTRIBUTES |
                SHGFI_TYPENAME
                );


            shellCache[lower] = rInfo;

            return rInfo;
        }

        public static Icon GetShellIcon(string extension)
        {
            var lower = extension.ToLower();

            if (iconCache.ContainsKey(lower))
            {
                return iconCache[lower];
            }

            var shellInfo = GetShellInfo(extension);

            var icon = Icon.FromHandle(shellInfo.hIcon);

            iconCache[lower] = icon;

            return icon;
        }

        #region Nested type: SHFILEINFO

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct SHFILEINFO
        {
            private const int MAX_PATH = 260;
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
        }

        #endregion
    }
}