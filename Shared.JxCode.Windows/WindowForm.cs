using System;
using System.Collections.Generic;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class WindowForm
    {
        private IntPtr hWnd;
        /// <summary>
        /// 窗体句柄
        /// </summary>
        public IntPtr HWND
        {
            get => hWnd;
            private set
            {
                this.hWnd = value;
                this.RefreshWindowRect();
            }
        }
        private int topPos = 0;
        private User32.Point position;
        private User32.Size size;
        /// <summary>
        /// 窗体大小
        /// </summary>
        public User32.Size Size
        {
            set
            {
                RefreshWindowRect();
                this.size = value;
                User32.SetWindowPos(this.hWnd, this.topPos, this.position.x, this.position.y, size.width, size.height, 0);
            }
            get
            {
                RefreshWindowRect();
                return size;
            }
        }
        /// <summary>
        /// 窗体位置
        /// </summary>
        public User32.Point Position
        {
            set
            {
                RefreshWindowRect();
                this.position = value;
                User32.SetWindowPos(this.hWnd, this.topPos, value.x, value.y, this.size.width, this.size.height, 0);
            }
            get
            {
                RefreshWindowRect();
                return this.position;
            }
        }
        /// <summary>
        /// 窗体父对象
        /// </summary>
        public IntPtr Parent
        {
            get => User32.GetParent(this.hWnd);
            set => User32.SetParent(this.hWnd, value);
        }
        /// <summary>
        /// 窗体标题
        /// </summary>
        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder(255);
                User32.GetWindowText(this.hWnd, sb, 255);

                return sb.ToString();
            }
            set
            {
                User32.SetWindowText(this.hWnd, value);
            }
        }
        /// <summary>
        /// 窗体类名
        /// </summary>
        public string ClassName
        {
            get
            {
                StringBuilder sb = new StringBuilder(256);
                User32.GetClassName(hWnd, sb, 256);
                return sb.ToString();
            }
        }
        /// <summary>
        /// 从句柄创建
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public WindowForm(IntPtr hWnd)
        {
            this.HWND = hWnd;
        }
        /// <summary>
        /// 从句柄创建
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        public WindowForm(int hWnd)
        {
            this.HWND = new IntPtr(hWnd);
        }
        /// <summary>
        /// 窗体实际大小同步至本类数据
        /// </summary>
        private void RefreshWindowRect()
        {
            User32.Rect rect = new User32.Rect();
            if (User32.GetWindowRect(this.hWnd, ref rect))
            {
                this.size = new User32.Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
                this.position = new User32.Point(rect.Left, rect.Top);
            }

        }
        /// <summary>
        /// 设置窗体图标
        /// </summary>
        /// <param name="icon"></param>
        public void SetIcon(string icon)
        {
            IntPtr result = Shell32.ExtractIcon(0, icon, 0);
            if (result != IntPtr.Zero)
                User32.SendMessage(this.hWnd, 0x80, IntPtr.Zero, result);
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseWindow()
        {
            User32.CloseWindow(this.hWnd);
        }
        /// <summary>
        /// 设置窗体置顶
        /// </summary>
        /// <param name="isTop"></param>
        public void SetTop(bool isTop)
        {
            RefreshWindowRect();
            this.topPos = isTop ? -1 : -2;
            User32.SetWindowPos(
                this.hWnd,
                this.topPos,
                this.position.x,
                this.position.y,
                this.size.width,
                this.size.height,
                0
            );
        }
        /// <summary>
        /// 从句柄创建
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static WindowForm CreateFromHWND(IntPtr hWnd)
        {
            return new WindowForm(hWnd);
        }
        /// <summary>
        /// 从标题创建
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static WindowForm CreateFromTitle(string title)
        {
            IntPtr result = User32.FindWindow(null, title);
            if (result == IntPtr.Zero)
                return null;
            else
                return new WindowForm(result);
        }
        /// <summary>
        /// 从位置创建
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static WindowForm CreateFromPosition(User32.Point position)
        {
            return new WindowForm(User32.WindowFromPoint(position));
        }
        /// <summary>
        /// 从鼠标位置创建
        /// </summary>
        /// <returns></returns>
        public static WindowForm CreateFromCursorPosition()
        {
            var pos = MouseUtil.GetMousePosition();
            return new WindowForm(User32.WindowFromPoint(pos));
        }
        /// <summary>
        /// 从PID创建
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static WindowForm CreateFromPID(IntPtr pid)
        {
            bool isReady = false;
            IntPtr hWnd = IntPtr.Zero;
            User32.EnumWindows((hwnd, lParam) =>
            {
                IntPtr _pid = IntPtr.Zero;
                User32.GetWindowThreadProcessId(hwnd, ref _pid);
                if (_pid == lParam)  //判断当前窗口是否属于本进程
                {
                    hWnd = hwnd;
                    isReady = true;
                    return false;
                }
                isReady = false;
                return true;
            }, pid);

            while (isReady)
                return new WindowForm(hWnd);
            return null;
        }
        /// <summary>
        /// 从当前程序的窗体创建
        /// </summary>
        /// <returns></returns>
        public static WindowForm CreateFromCurrentPid()
        {
            IntPtr PID = new IntPtr(System.Diagnostics.Process.GetCurrentProcess().Id);
            return CreateFromPID(PID);
        }
        /// <summary>
        /// 窗体是否存在
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static bool Exist(IntPtr hWnd)
        {
            return User32.IsWindow(hWnd);
        }
        /// <summary>
        /// 最大化
        /// </summary>
        public void Maximize()
        {
            User32.SendMessage(this.hWnd, WindowsMessage.WM_SYSCOMMAND, SysCommand.SC_MAXIMIZE);
        }
        /// <summary>
        /// 最小化
        /// </summary>
        public void Minimize()
        {
            User32.SendMessage(this.hWnd, WindowsMessage.WM_SYSCOMMAND, SysCommand.SC_MINIMIZE);
        }
        /// <summary>
        /// 还原
        /// </summary>
        public void Restore()
        {
            User32.SendMessage(this.hWnd, WindowsMessage.WM_SYSCOMMAND, SysCommand.SC_RESTORE);
        }
        /// <summary>
        /// 发送粘贴
        /// </summary>
        public void Paste()
        {
            User32.SendMessage(this.hWnd, WindowsMessage.WM_PASTE, 0, 0);
        }
        /// <summary>
        /// 设置焦点
        /// </summary>
        public void SetFocus()
        {
            User32.SetForegroundWindow(this.hWnd);
        }
    }
}
