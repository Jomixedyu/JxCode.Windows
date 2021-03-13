using System;

using JxCode.Windows.Native;
using System.Runtime.InteropServices;

using WindowsLongMessage = JxCode.Windows.Native.User32.GWL_WindowsLongMessage;
using WindowsMessage = JxCode.Windows.Native.User32.WM_WindowsMessage;
using WindowsActiveMessage = JxCode.Windows.Native.User32.WA_WindowsActiveMessage;

namespace JxCode.Windows
{
    public interface IWinformMessageProc
    {
        /// <summary>
        /// 窗口收到关闭消息，返回一个值来确定是否关闭
        /// </summary>
        /// <returns>true为不关闭，false为关闭</returns>
        bool OnClose();
        /// <summary>
        /// 窗口收到激活
        /// </summary>
        void OnActive();
        /// <summary>
        /// 窗口失去激活
        /// </summary>
        void OnInactive();
    }
    public class WinformMessageProc : IDisposable
    {
        protected IntPtr hWnd;
        protected IntPtr msgcb_src;
        protected IWinformMessageProc proc;

        public WinformMessageProc(IntPtr hWnd, IWinformMessageProc proc)
        {
            this.proc = proc;
            this.msgcb_src = User32.GetWindowLong(hWnd, WindowsLongMessage.GWL_WNDPROC);
            this.hWnd = User32.SetWindowLong(hWnd, WindowsLongMessage.GWL_WNDPROC, WndProc);
        }

        protected virtual IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case (int)WindowsMessage.WM_ACTIVATE:
                    switch ((uint)wParam)
                    {
                        case (uint)WindowsActiveMessage.WA_INACTIVE:
                            this.proc.OnInactive();
                            break;
                        case (uint)WindowsActiveMessage.WA_ACTIVE:
                        case (uint)WindowsActiveMessage.WA_CLICKACTIVE:
                            this.proc.OnActive();
                            break;
                    }
                    break;
                case (int)WindowsMessage.WM_CLOSE:
                    if (!this.proc.OnClose())
                    {
                        return (IntPtr)0;
                    }
                    break;
                default:
                    break;
            }
            return User32.CallWindowProc(this.hWnd, hWnd, msg, wParam, lParam);
        }

        protected bool isDispose = false;
        public virtual void Dispose()
        {
            if (this.isDispose)
            {
                return;
            }
            var ptr = Marshal.GetDelegateForFunctionPointer(this.msgcb_src, typeof(User32.WindowLongCallBack)) as User32.WindowLongCallBack;
            User32.SetWindowLong(this.hWnd, WindowsLongMessage.GWL_WNDPROC, ptr);
            this.isDispose = true;
            GC.SuppressFinalize(this);
        }

    }
}
