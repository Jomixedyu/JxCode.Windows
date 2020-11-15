using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JxCode.Windows.SoftUtility
{
    public class JavaInfo
    {
        public string JavaHome { get; private set; }
        public bool Is64Bit { get; private set; }
        public int MainVersion { get; private set; }
        public string FullVersion { get; private set; }

        public string JavaExe
        {
            get => this.JavaHome + "\\bin\\java.exe";
        }
        public string JavawExe
        {
            get => this.JavaHome + "\\bin\\javaw.exe";
        }

        public JavaInfo()
        {

        }
        public JavaInfo(string javaHome, bool is64Bit, int mainVersion, string fullVersion)
        {
            this.JavaHome = javaHome;
            this.Is64Bit = is64Bit;
            this.MainVersion = mainVersion;
            this.FullVersion = fullVersion;
        }

        public override string ToString()
        {
            return "JavaHome: " + this.JavaHome + "   is64Bit: " + this.Is64Bit.ToString();
        }

        public static int GetMainVersion(string fullVersion)
        {
            string[] versionSubArray = fullVersion.Split('.');
            if (versionSubArray.Length < 2)
            {
                return 0;
            }

            int mainVersion = 0;
            int.TryParse(versionSubArray[1], out mainVersion);

            return mainVersion;
        }

        /// <summary>
        /// 获取该计算机中的所有Java信息
        /// </summary>
        /// <returns></returns>
        public static IList<JavaInfo> FindJava()
        {
            RegistryKey registry;
            registry = Registry.LocalMachine.OpenSubKey("SOFTWARE");

            //return
            IList<JavaInfo> javaInfos = new List<JavaInfo>();

            bool is64Bit = Environment.Is64BitOperatingSystem;

        label_r64bit: //在64系统下重新处理32位java

            RegistryKey registryKey = registry.OpenSubKey("JavaSoft");
            registryKey = registryKey?.OpenSubKey("Java Runtime Environment");
            if (registryKey == null)
            {
                return javaInfos;
            }

            string[] javaVers = registryKey.GetSubKeyNames();
            for (int i = 0; i < javaVers.Length; i++)
            {
                string fullVersionName = javaVers[i];
                RegistryKey javaInfoKey = registryKey.OpenSubKey(fullVersionName);

                int mainVersion = GetMainVersion(javaVers[i]);

                JavaInfo info = new JavaInfo(
                    (string)javaInfoKey.GetValue("JavaHome"),
                    is64Bit,
                    mainVersion,
                    fullVersionName);

                javaInfos.Add(info);

            }

            if (is64Bit)
            {
                //如果是64位系统，打开32注册表跳转回去继续处理
                is64Bit = false;
                registry = registry.OpenSubKey("Wow6432Node");
                goto label_r64bit;
            }

            return javaInfos;
        }

        /// <summary>
        /// 从Java执行程序或目录中获取Java信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JavaInfo GetJavaInfo(string path)
        {
            bool isFile = false;
            bool isDir = false;
            if (File.Exists(path))
            {
                isFile = true;
            }
            else if (Directory.Exists(path))
            {
                isDir = true;
            }
            if (!isFile && !isDir)
            {
                return null;
            }

            string dirPath = string.Empty;
            if (isFile)
            {
                dirPath = Path.GetDirectoryName(path);
            }
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            while (dirInfo != null)
            {
                if (File.Exists(dirInfo.FullName + "\\release"))
                {
                    break;
                }
                else
                {
                    dirInfo = dirInfo.Parent;
                }
            }

            if (dirInfo == null)
            {
                return null;
            }

            string[] releaseContent = File.ReadAllLines(dirInfo.FullName + "\\release");

            JavaInfo javaInfo = new JavaInfo();
            javaInfo.JavaHome = dirInfo.FullName;

            foreach (var item in releaseContent)
            {
                string[] items = item.Split('=');
                if (items[0] == "JAVA_VERSION")
                {
                    javaInfo.FullVersion = items[1].Replace("\"", "");
                    javaInfo.MainVersion = GetMainVersion(javaInfo.FullVersion);
                }
                else if (items[0] == "OS_ARCH")
                {
                    javaInfo.Is64Bit = items[1].Replace("\"", "") == "amd64";
                }
            }

            return javaInfo;
        }

    }


}
