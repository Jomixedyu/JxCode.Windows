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
        private User32.HookProc m_kbdHookProcedure;
        public event Action<Keys> keyMsg;
        public void Dispose()
        {
            if (this.m_kbdHook == IntPtr.Zero)
                return;

            User32.UnhookWindowsHookEx(this.m_kbdHook);
            this.m_kbdHook = IntPtr.Zero;

        }
        private int HookProc(int nCode, int wParam, IntPtr lParam)
        {
            keyMsg.Invoke((Keys)nCode);
            return User32.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        public void Start()
        {
            if (this.m_kbdHook == IntPtr.Zero)
                return;

            this.m_kbdHookProcedure = this.HookProc;
            IntPtr moduleHandle = Kernel32.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            this.m_kbdHook = User32.SetWindowsHookEx(13, m_kbdHookProcedure, moduleHandle, 0);
        }
    }
}
