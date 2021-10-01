using System;
using System.Collections.Generic;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public sealed class INIFile
    {
        private string filepath = string.Empty;
        public string FilePath => filepath;

        public INISection this[string sectionName]
        {
            get
            {
                return new INISection(this, sectionName);
            }
        }

        public INIFile(string filepath)
        {
            this.filepath = filepath;
        }

        public INISection GetSection(string name) => this[name];

        public void SetValue(string sectionName, string key, object value)
        {
            Kernel32.WritePrivateProfileString(sectionName, key, value.ToString(), FilePath);
        }
        public string GetValue(string sectionName, string key)
        {
            byte[] buf = new byte[255];
            Kernel32.GetPrivateProfileString(sectionName, key, string.Empty, buf, 255, FilePath);
            string s = Encoding.GetEncoding(0).GetString(buf);
            s = s.Substring(0, buf.Length);
            return s;
        }
    }

    public sealed class INISection
    {
        private INIFile parent;
        private string sectionName;
        public INISection(INIFile parent, string sectionName)
        {
            this.parent = parent;
            this.sectionName = sectionName;
        }
        public string this[string key] => GetValue(key);

        public void SetValue(string key, object value)
        {
            this.parent.SetValue(sectionName, key, value);
        }
        public string GetValue(string key)
        {
            return this.parent.GetValue(sectionName, key);
        }
        
    }

}
