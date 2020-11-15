using System;
using System.Collections.Generic;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class NotifyIcon
    {
        private bool isEnable = false;
        private readonly IntPtr icon;
        private Shell32.NotifyIconData nid;
        private string text = string.Empty;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                nid.szTip = ToCharArray(value);
                if (isEnable)
                {
                    Shell32.Shell_NotifyIconW(Shell32.NotityMessage.NIM_MODIFY, nid);
                }
            }
        }
        public NotifyIcon(string iconPath, IntPtr hWnd)
        {
            icon = Shell32.ExtractIcon(0, iconPath, 0);
            int structSize = 0;
            if (Environment.Is64BitOperatingSystem)
                structSize = 160;
            else
                structSize = 152;
            nid = new Shell32.NotifyIconData()
            {
                cbSize = structSize,
                hIcon = icon,
                hWnd = hWnd,
                szTip = ToCharArray(Text),
                uFlags = Shell32.NotifyFlag.NIF_ICON 
                        | Shell32.NotifyFlag.NIF_TIP 
                        | Shell32.NotifyFlag.NIF_MESSAGE,
                uCallbackMessage = (uint)WindowsMessage.WM_PASTE ,
            };
        }

        public void Enable()
        {
            Shell32.Shell_NotifyIconW(Shell32.NotityMessage.NIM_ADD, this.nid);
            isEnable = true;
        }
        public void Disable()
        {
            Shell32.Shell_NotifyIconW(Shell32.NotityMessage.NIM_DELETE, this.nid);
            isEnable = false;
        }
        //定长字符数组
        private char[] ToCharArray(string str)
        {
            //固定64长度，64个字符，总共128字节长度
            int length = 64;
            int strLen = str.Length;
            if (strLen == length)
                return str.ToCharArray();
            else if (strLen > length)
            {
                //过长裁剪
                return str.ToCharArray(0, length);
            }
            else
            {
                //填充已有，剩下的char默认就是\0
                char[] chars = new char[length];
                for (int i = 0; i < chars.Length; i++)
                {
                    if (i < str.Length)
                    {
                        chars[i] = str[i];
                    }
                }
                return chars;
            }

        }
    }


}
