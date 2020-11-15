using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public static class MessageBox
    {
        public static DialogResult Show(string text)
        {
            return Show(text, Assembly.GetCallingAssembly().GetName().Name);
        }
        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxButtons.Ok);
        }
        public static DialogResult Show(string text, string caption, MessageBoxButtons button)
        {
            return (DialogResult)User32.MessageBox(default, text, caption, (uint)button);
        }
        public static DialogResult Show(IntPtr OnwerHWND, string text, string caption, MessageBoxButtons button)
        {
            return (DialogResult)User32.MessageBox(OnwerHWND, text, caption, (uint)button);
        }
    }
    public enum MessageBoxButtons
    {
        Ok                = 0x00,
        OkCancel          = 0x01,
        AbortRetryIgnore  = 0x02,
        YesNoCancel       = 0x03,
        YesNo             = 0x04,
        RetryCancel       = 0x05,
        CancelTryContinue = 0x06,

        IconHand          = 0x10,
        IconQuestion      = 0x20,
        UcibExclamation   = 0x30,
        IconAsterisk      = 0x40,
        UserIcon          = 0x80,
        IconWarning       = 0x30,
        IconError         = 0x10,
        IconInformation   = 0x40,
        IconStop          = 0x10,
    }
    public enum DialogResult
    {
         Ok         =   1 ,
         Cancel     =   2 ,
         Abort      =   3 ,
         Retry      =   4 ,
         Ignore     =   5 ,
         Yes        =   6 ,
         No         =   7 ,
         Close      =   8 ,
         Help       =   9 ,
         TryAgain   =   10,
         Continue   =   11,
    }
}
