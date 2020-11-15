using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace JxCode.Windows.Native
{
    public class Winmm
    {
        private const string DLL_NAME = @"winmm.dll";

        [DllImport("winmm.dll", EntryPoint = "mciSendString" , CharSet = CharSet.Auto)]
        public static extern int mciSendString
            (string lpszCommand, string lpszReturnString, uint cchReturn, int hwndCallback);
        
        [DllImport(DLL_NAME, EntryPoint = "mciGetErrorString")]
        public static extern int mciGetErrorString(int mcierr, StringBuilder pszText, uint cchText);
    }
}
