using System;
using System.Runtime.InteropServices;
using DWORD = System.Int32;
using TCHAR = System.Char;
using UINT = System.UInt32;

namespace JxCode.Windows.Native
{
    public static class Shell32
    {
        private const string DLL_NAME = "shell32.dll";
        [DllImport(DLL_NAME, EntryPoint = "ExtractIcon", CharSet = CharSet.Unicode)]
        public static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);
        [DllImport(DLL_NAME, EntryPoint = "Shell_NotifyIconW", CharSet = CharSet.Unicode)]
        public static extern bool Shell_NotifyIconW(NIM_NotityMessage dwMessage, NotifyIconData lpdata);

        public enum NIM_NotityMessage
        {
            NIM_ADD        = 0x00000000,
            NIM_MODIFY     = 0x00000001,
            NIM_DELETE     = 0x00000002,
            NIM_SETFOCUS   = 0x00000003,
            NIM_SETVERSION = 0x00000004,
        }
        public enum NIF_NotifyFlag
        {
            NIF_MESSAGE  = 0x00000001,
            NIF_ICON     = 0x00000002,
            NIF_TIP      = 0x00000004,
            NIF_STATE    = 0x00000008,
            NIF_INFO     = 0x00000010,
            NIF_GUID     = 0x00000020,
            NIF_REALTIME = 0x00000040,
            NIF_SHOWTIP  = 0x00000080,
        }
        /// <summary>
        /// 32bit length: 152 ; 64bit length: 160
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)] 
        public struct NotifyIconData
        {
            public DWORD cbSize; 
            public IntPtr hWnd;
            public UINT uID;
            public NIF_NotifyFlag uFlags;
            public UINT uCallbackMessage;
            public IntPtr hIcon;

            /// <summary>
            /// 固定数组长度：64
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public char[] szTip; //128
        }

    }
}
