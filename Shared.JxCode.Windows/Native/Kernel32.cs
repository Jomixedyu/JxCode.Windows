
using System.Runtime.InteropServices;

namespace JxCode.Windows.Native
{
    public static class Kernel32
    {
        private const string DLL_NAME = "kernel32.dll";
        [DllImport(DLL_NAME, EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        [DllImport(DLL_NAME, EntryPoint = "WritePrivateProfileString")]
        public static extern int WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}
