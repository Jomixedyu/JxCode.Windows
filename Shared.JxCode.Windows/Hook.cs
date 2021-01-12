using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class Hook : IDisposable
    {
        private IntPtr m_kbdHook = IntPtr.Zero;
        public event Action<Keys> keyMsg;
        User32.HookProc hookProcCallBack;

        public void Dispose()
        {
            if (this.m_kbdHook == IntPtr.Zero)
                return;

            User32.UnhookWindowsHookEx(this.m_kbdHook);
            this.m_kbdHook = IntPtr.Zero;
        }
        private int HookProc(int nCode, int wParam, IntPtr lParam)
        {
            Console.WriteLine("+++");

            this.keyMsg.Invoke((Keys)nCode);
            return User32.CallNextHookEx(m_kbdHook, nCode, wParam, lParam);
        }
        public void Start()
        {
            if (this.m_kbdHook != IntPtr.Zero)
                return;
            this.hookProcCallBack = new User32.HookProc(this.HookProc);
            string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
            IntPtr moduleHandle = Kernel32.GetModuleHandle(moduleName);
            this.m_kbdHook = User32.SetWindowsHookEx(13, this.hookProcCallBack, moduleHandle, 0);
        }
    }
}
