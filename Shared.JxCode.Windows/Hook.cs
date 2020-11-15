using System;
using System.Collections.Generic;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class Hook : IDisposable
    {
        private IntPtr m_kbdHook = IntPtr.Zero;
        private User32.HookProc m_kbdHookProcedure;
        private bool isGlobal = false;

        public void Dispose()
        {
            
        }

        public void Start()
        {

        }
    }
}
