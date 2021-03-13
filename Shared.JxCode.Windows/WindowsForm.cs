using System;
using System.Collections.Generic;
using System.Text;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class WindowsForm
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

        public WindowsForm GetParent()
        {
            IntPtr ptr = this.Parent;
            if(ptr == IntPtr.Zero)
            {
                return null;
            }
            return CreateFromHWND(ptr);
        }
        public void SetParent(WindowsForm windowsForm)
        {
            this.Parent = windowsForm.hWnd;
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

        //public bool IsAcceptMessage
        //{
        //    get
        //    {
                
        //    }
        //}

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

        public IntPtr[] GetChildWindows()
        {
            List<IntPtr> list = new List<IntPtr>();
            User32.EnumChildWindows(this.hWnd,
                (hwnd, lparam) =>
                {
                    list.Add(hwnd);
                    return true;
                }, 0);

            return list.ToArray();
        }

        public WindowsForm[] GetChildWindowsForms()
        {
            IntPtr[] intptr = this.GetChildWindows();
            WindowsForm[] forms = new WindowsForm[intptr.Length];
            for (int i = 0; i < intptr.Length; i++)
            {
                forms[i] = CreateFromHWND(intptr[i]);
            }
            return forms;
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
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_SYSCOMMAND, User32.SC_SysCommand.SC_MAXIMIZE);
        }
        /// <summary>
        /// 最小化
        /// </summary>
        public void Minimize()
        {
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_SYSCOMMAND, User32.SC_SysCommand.SC_MINIMIZE);
        }
        /// <summary>
        /// 还原
        /// </summary>
        public void Restore()
        {
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_SYSCOMMAND, User32.SC_SysCommand.SC_RESTORE);
        }
        /// <summary>
        /// 发送粘贴
        /// </summary>
        public void Paste()
        {
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_PASTE, 0, 0);
        }
        /// <summary>
        /// 设置焦点
        /// </summary>
        public void SetFocus()
        {
            User32.SetForegroundWindow(this.hWnd);
        }

        public override bool Equals(object obj)
        {
            WindowsForm form = obj as WindowsForm;
            return form != null && this.hWnd == form.hWnd;
        }


        /// <summary>
        /// 从句柄创建
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        protected WindowsForm(IntPtr hWnd)
        {
            this.HWND = hWnd;
        }

        public enum BorderStyle
        {
            None,
            Sizable,
        }
        public bool SetBorderStyle(BorderStyle style)
        {

            var oldLong = (User32.WS_WindowStyle)User32.GetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE);
            var newLong = oldLong;
            if (oldLong.HasFlag(User32.WS_WindowStyle.WS_CAPTION))
            {
                //newLong = oldLong & ~User32.WS_WindowStyle.WS_CAPTION;
                newLong = oldLong & ~User32.WS_WindowStyle.WS_OVERLAPPEDWINDOW;
            }

            //newLong = newLong & ~(uint)(User32.WSEX_ExtendedWindowStyle.WS_EX_WINDOWEDGE
            //    | User32.WSEX_ExtendedWindowStyle.WS_EX_DLGMODALFRAME);

            User32.SetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE, newLong);
            if(((User32.WS_WindowStyle)User32.GetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE)).HasFlag(User32.WS_WindowStyle.WS_CAPTION))
            {
                return false;
            }
            return true;
            //return User32.SetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE, newLong) != IntPtr.Zero;
        }

        public IntPtr SetWindowLong(User32.GWL_WindowsLongMessage msg, uint dw)
        {
            return User32.SetWindowLong(this.HWND, msg, dw);
        }
        public void SetWindowStyle(uint style)
        {
            User32.SetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE, style);
        }
        public IntPtr GetWindowLong(int nIndex)
        {
            return User32.GetWindowLong(this.hWnd, nIndex);
        }

        public uint GetWindowStyle()
        {
            return (uint)User32.GetWindowLong(this.hWnd, User32.GWL_WindowsLongMessage.GWL_STYLE);
        }

        public void Active()
        {
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_ACTIVATE, (IntPtr)User32.WA_WindowsActiveMessage.WA_ACTIVE, IntPtr.Zero);
        }
        public void Inactive()
        {
            User32.SendMessage(this.hWnd, User32.WM_WindowsMessage.WM_ACTIVATE, (IntPtr)User32.WA_WindowsActiveMessage.WA_INACTIVE, IntPtr.Zero);
        }

        #region Factory
        /// <summary>
        /// 从句柄创建
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static WindowsForm CreateFromHWND(IntPtr hWnd)
        {
            if(hWnd == IntPtr.Zero)
            {
                return null;
            }
            return new WindowsForm(hWnd);
        }
        /// <summary>
        /// 从标题创建
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static WindowsForm CreateFromTitle(string title)
        {
            IntPtr result = User32.FindWindow(null, title);
            if (result == IntPtr.Zero)
            {
                return null;
            }
            return new WindowsForm(result);
        }
        /// <summary>
        /// 从位置创建
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static WindowsForm CreateFromPosition(User32.Point position)
        {
            IntPtr ptr = User32.WindowFromPoint(position);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }
            return new WindowsForm(ptr);
        }
        /// <summary>
        /// 从鼠标位置创建
        /// </summary>
        /// <returns></returns>
        public static WindowsForm CreateFromCursorPosition()
        {
            var pos = MouseUtil.GetMousePosition();
            IntPtr ptr = User32.WindowFromPoint(pos);
            if(ptr == IntPtr.Zero)
            {
                return null;
            }
            return new WindowsForm(ptr);
        }
        /// <summary>
        /// 从PID创建
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static WindowsForm CreateFromPID(IntPtr pid)
        {
            IntPtr hWnd = IntPtr.Zero;
            //阻塞函数
            User32.EnumWindows((hwnd, lParam) =>
            {
                IntPtr _pid = IntPtr.Zero;
                User32.GetWindowThreadProcessId(hwnd, ref _pid);
                //判断当前窗口是否属于本进程
                if (_pid == lParam)
                {
                    hWnd = hwnd;
                    return false;
                }
                //继续循环
                return true;
            }, pid);

            if(hWnd == IntPtr.Zero)
            {
                return null;
            }

            return new WindowsForm(hWnd);
        }
        /// <summary>
        /// 从当前程序的窗体创建
        /// </summary>
        /// <returns></returns>
        public static WindowsForm CreateFromCurrentPid()
        {
            IntPtr PID = new IntPtr(System.Diagnostics.Process.GetCurrentProcess().Id);
            return CreateFromPID(PID);
        }
        /// <summary>
        /// 从调用线程的活动窗口创建
        /// </summary>
        /// <returns></returns>
        public static WindowsForm CreateFromCurThreadActiveWindow()
        {
            return new WindowsForm(User32.GetActiveWindow());
        }
        #endregion
    }
}
