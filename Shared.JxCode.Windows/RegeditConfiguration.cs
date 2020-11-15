using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;

namespace JxCode.Windows
{
    public class RegeditConfiguration : IEnumerable<KeyValuePair<string, object>>
    {
        private string name;

        private Dictionary<string, object> data = new Dictionary<string, object>();
        /// <summary>
        /// 构造后默认读取注册表
        /// </summary>
        /// <param name="name"></param>
        public RegeditConfiguration(string name = null)
        {
            this.name = name != null ? name : Assembly.GetExecutingAssembly().FullName;
            this.Reload();
        }

        /// <summary>
        /// 重新读取注册表
        /// </summary>
        public void Reload()
        {
            this.data.Clear();
            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey cfg = HKCU.OpenSubKey(this.name);
            if (cfg != null)
            {
                var names = cfg.GetValueNames();
                foreach (var item in names)
                {
                    this.data.Add(item, cfg.GetValue(item));
                }
            }
        }
        /// <summary>
        /// 保存注册表
        /// </summary>
        public void Save()
        {
            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey cfg = HKCU.OpenSubKey(this.name, true);
            if (cfg == null)
                cfg = HKCU.CreateSubKey(this.name);
            foreach (KeyValuePair<string, object> item in this.data)
            {
                cfg.SetValue(item.Key, item.Value);
            }
        }

        /// <summary>
        /// 删除注册表
        /// </summary>
        /// <param name="name"></param>
        public static void Delete(string name)
        {
            Registry.CurrentUser.OpenSubKey("Software", true).DeleteSubKey(name);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)this.data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)this.data).GetEnumerator();
        }

        public static string GetSetting(string appName, string key)
        {
            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software");
            RegistryKey cfg = HKCU.OpenSubKey(appName);
            if (cfg == null) return null;
            return (string)cfg.GetValue(key);
        }
        public static void SetSetting(string appName, string key, string value)
        {
            RegistryKey HKCU = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey cfg = HKCU.OpenSubKey(appName, true);
            if (cfg == null)
                cfg = HKCU.CreateSubKey(appName);
            cfg.SetValue(key, value);
        }

        public object this[string key]
        {
            get
            {
                if (this.data.ContainsKey(key))
                    return this.data[key];
                else
                    return null;
            }
            set
            {
                if (this.data.ContainsKey(key))
                {
                    if (value == null)
                    {
                        this.data.Remove(key);
                    }
                    else
                    {
                        this.data[key] = value;
                    }
                }
                else
                {
                    this.data.Add(key, value);
                }
            }
        }
    }
}
