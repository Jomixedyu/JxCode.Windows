
using System.Diagnostics;
using System.Threading;

namespace JxCode.Windows
{
    public class App
    {
        /// <summary>
        /// 程序运行的工作路径
        /// </summary>
        public static string Path
        {
            get { return global::System.Environment.CurrentDirectory; }
        }
        /// <summary>
        /// 程序所在路径
        /// </summary>
        public static string BasePath
        {
            get
            {
                string t = global::System.AppDomain.CurrentDomain.BaseDirectory;
                return t.Substring(0, t.Length - 1);
            }
        }
        /// <summary>
        /// Exe的完整路径
        /// </summary>
        public static string FullPath
        {
            get { return global::System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; }
        }
        /// <summary>
        /// Exe的名字（不含扩展名）
        /// </summary>
        public static string EXEName
        {
            get { return global::System.IO.Path.GetFileNameWithoutExtension(FullPath); }
        }
        /// <summary>
        /// 是否有程序实例在运行
        /// </summary>
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