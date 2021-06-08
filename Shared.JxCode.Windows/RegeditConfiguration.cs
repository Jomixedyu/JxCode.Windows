using Microsoft.Win32;
using System.Reflection;

namespace JxCode.Windows
{
    public static class RegeditConfiguration
    {
        public static string GetSetting(string key, string appName = null)
        {
            appName = appName ?? Assembly.GetExecutingAssembly().FullName;

            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey cfg = HKCU.OpenSubKey(appName);
            if (cfg == null) return null;
            return (string)cfg.GetValue(key);
        }
        public static void SetSetting(string key, string value, string appName = null)
        {
            appName = appName ?? Assembly.GetExecutingAssembly().FullName;
            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey cfg = HKCU.OpenSubKey(appName, true);
            if (cfg == null)
            {
                cfg = HKCU.CreateSubKey(appName);
            }
            cfg.SetValue(key, value);
        }
    }
}
