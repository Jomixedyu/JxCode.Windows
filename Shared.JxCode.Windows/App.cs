
using System.Diagnostics;
using System.Threading;

namespace JxCode.Windows
{
    public class App
    {
        public static string Path
        {
            get { return global::System.Environment.CurrentDirectory; }
        }
        public static string BasePath
        {
            get
            {
                string t = global::System.AppDomain.CurrentDomain.BaseDirectory;
                return t.Substring(0, t.Length - 1);
            }
        }
        public static string FullPath
        {
            get { return global::System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; }
        }
        public static string EXEName
        {
            get { return global::System.IO.Path.GetFileNameWithoutExtension(FullPath); }
        }
        public static bool PrevInstance
        {
            get
            {
                string processName = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(processName);
                if(processes.Length > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static void End(int exitCode = 0)
        {
            System.Environment.Exit(exitCode);
        }
    }
}