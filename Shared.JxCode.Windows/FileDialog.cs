using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace JxCode.Windows
{
    public class FileDialog
    {
        private const string DLL_NAME = "comdlg32.dll";
        #region nativeDefine
        [DllImport(DLL_NAME, SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        private extern static int GetOpenFileName(ref OPENFILENAME pOpenfilename);
        [DllImport(DLL_NAME, SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        private extern static bool GetSaveFileName(ref OPENFILENAME pOpenfilename);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct OPENFILENAME
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public int hInstance;
            public string lpstrFilter;
            public string lpstrCustomFilter;
            public int nMaxCustFilter;
            public int nFilterIndex;
            public string lpstrFile;
            public int nMaxFile;
            public string lpstrFileTitle;
            public int nMaxFileTitle;
            public string lpstrInitialDir;
            public string lpstrTitle;
            public OFNEnum Flags;
            public short nFileOffset;
            public short nFileExtension;
            public string lpstrDefExt;
            public int lCustData;
            public IntPtr lpfnHook;
            public string lpTemplateName;
        }
        private enum OFNEnum : uint
        {
            OFN_READONLY = 0x00000001,
            OFN_OVERWRITEPROMPT = 0x00000002,
            OFN_HIDEREADONLY = 0x00000004,
            OFN_NOCHANGEDIR = 0x00000008,
            OFN_SHOWHELP = 0x00000010,
            OFN_ENABLEHOOK = 0x00000020,
            OFN_ENABLETEMPLATE = 0x00000040,
            OFN_ENABLETEMPLATEHANDLE = 0x00000080,
            OFN_NOVALIDATE = 0x00000100,
            OFN_ALLOWMULTISELECT = 0x00000200,
            OFN_EXTENSIONDIFFERENT = 0x00000400,
            OFN_PATHMUSTEXIST = 0x00000800,
            OFN_FILEMUSTEXIST = 0x00001000,
            OFN_CREATEPROMPT = 0x00002000,
            OFN_SHAREAWARE = 0x00004000,
            OFN_NOREADONLYRETURN = 0x00008000,
            OFN_NOTESTFILECREATE = 0x00010000,
            OFN_NONETWORKBUTTON = 0x00020000,
            OFN_NOLONGNAMES = 0x00040000,
            OFN_EXPLORER = 0x00080000,
            OFN_NODEREFERENCELINKS = 0x00100000,
            OFN_LONGNAMES = 0x00200000,
            OFN_ENABLEINCLUDENOTIFY = 0x00400000,
            OFN_ENABLESIZING = 0x00800000,
            OFN_DONTADDTORECENT = 0x02000000,
            OFN_FORCESHOWHIDDEN = 0x10000000,
        }
        #endregion
        private static OPENFILENAME GetOFN(string dirPath, string filter, string title, string defaultFilename)
        {
            OPENFILENAME ofn = new OPENFILENAME();
            ofn.lStructSize = Marshal.SizeOf(ofn);
            ofn.lpstrFilter = filter.Replace('|', '\0') + '\0';
            ofn.nFilterIndex = 1;
            ofn.lpstrInitialDir = dirPath;

            char[] _filename = new char[256];
            char[] _defaultFilename = defaultFilename.ToCharArray();
            Array.Copy(_defaultFilename, _filename, _defaultFilename.Length);
            string filename = new string(_filename);

            ofn.lpstrTitle = title;
            ofn.lpstrFile = filename;
            ofn.nMaxFile = ofn.lpstrFile.Length;

            ofn.Flags = OFNEnum.OFN_PATHMUSTEXIST | OFNEnum.OFN_FILEMUSTEXIST;

            return ofn;
        }
        /// <summary>
        /// 打开文件对话框
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <param name="defaultFilename"></param>
        /// <returns>打开的文件名，如果取消则为null</returns>
        public static string OpenFileDialog(string dirPath, string filter, string title = "OpenFileDialog", string defaultFilename = "")
        {
            OPENFILENAME ofn = GetOFN(dirPath, filter, title, defaultFilename);
            int result = GetOpenFileName(ref ofn);
            return result > 0 ? ofn.lpstrFile : null;
        }
        /// <summary>
        /// 保存文件的对话框
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <param name="defaultFilename"></param>
        /// <returns>保存的文件名，如果取消则为null</returns>
        public static string SaveFileDialog(string dirPath,
            string filter = "All(*.*)|*.*",
            string title = "SaveFileDialog",
            string defaultFilename = "")
        {
            OPENFILENAME ofn = GetOFN(dirPath, filter, title, defaultFilename);
            bool result = GetSaveFileName(ref ofn);
            return result ? ofn.lpstrFile : null;
        }
    }
}
