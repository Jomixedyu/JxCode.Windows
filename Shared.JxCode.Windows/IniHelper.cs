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

        private Dictionary<string, INISection> sections;

        public INISection this[string sectionName] => this.sections[sectionName];

        public INIFile(string filepath)
        {
            this.filepath = filepath;
            this.sections = new Dictionary<string, INISection>();
        }
        public INISection AddSection(string name)
        {
            var s = new INISection(this, name);
            this.sections.Add(name, s);
            return s;
        }
        public INISection GetSection(string name) => this[name];
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
            Kernel32.WritePrivateProfileString(sectionName, key, value.ToString(), parent.FilePath);
        }
        public string GetValue(string key)
        {
            byte[] buf = new byte[255];
            Kernel32.GetPrivateProfileString(this.sectionName, key, string.Empty, buf, 255, this.parent.FilePath);
            string s = Encoding.GetEncoding(0).GetString(buf);
            s = s.Substring(0, buf.Length);
            return s;
        }
        
    }

}
