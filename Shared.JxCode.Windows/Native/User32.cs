using System;
using System.Runtime.InteropServices;
using System.Text;

namespace JxCode.Windows.Native
{
    public static class User32
    {
        private const string DLL_NAME = "user32.dll";
        public delegate bool EnumWindowsCallBack(IntPtr hwnd, IntPtr lParam);
        [DllImport(DLL_NAME, EntryPoint = "SetWindowText", CharSet = CharSet.Unicode)]
        public static extern bool SetWindowText(IntPtr hwnd, string title);
        [DllImport(DLL_NAME, EntryPoint = "EnumWindows")]
        public static extern int EnumWindows(EnumWindowsCallBack lpEnumFunc, IntPtr lParam);
        [DllImport(DLL_NAME, EntryPoint = "GetWindowThreadProcessId")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref IntPtr lpdwProcessId);
        [DllImport(DLL_NAME, EntryPoint = "CloseWindow")]
        public static extern bool CloseWindow(IntPtr hwnd);

        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, string lParam);
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, uint wParam, uint lParam);
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, WindowsMessage wMsg, uint wParam, uint lParam);
        public static int SendMessage(IntPtr hWnd, WindowsMessage wMsg, SysCommand wParam)
        {
            return SendMessage(hWnd, wMsg, (uint)wParam, 0);
        }
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, WindowsMessage wMsg, uint wParam, string lParam);
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, WindowsMessage wMsg, IntPtr wParam, string lParam);
        [DllImport(DLL_NAME, EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, WindowsMessage wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport(DLL_NAME, EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport(DLL_NAME, EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport(DLL_NAME, EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport(DLL_NAME, EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport(DLL_NAME, EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport(DLL_NAME, EntryPoint = "GetWindowRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport(DLL_NAME, EntryPoint = "keybd_event")]
        public static extern void keybd_event(Keys bVk, byte bScan, KeyEvent dwFlags, uint dwExtraInfo);
        public enum KeyEvent
        {
            down = 0,
            up = 2
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dwData">仅dwFlags为MOUSEEVENTF_WHEEL，则dwData指定鼠标轮移动的数量。正值表明鼠标轮向前转动，即远离用户的方向</param>
        /// <param name="dwExtraInfo">应用程序调用函数GetMessageExtraInfo来获得此附加信息</param>
        [DllImport(DLL_NAME, EntryPoint = "mouse_event")]
        public static extern void mouse_event(MouseEventType dwFlags, int dx = 0, int dy = 0, int dwData = 0, ulong dwExtraInfo = 0);
        [DllImport(DLL_NAME, EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(ref Point point);
        [DllImport(DLL_NAME, EntryPoint = "SetCursorPos")]
        public static extern bool SetCursorPos(int x, int y);
        public struct Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public override bool Equals(object obj)
            {
                return obj is Point point &&
                       x == point.x &&
                       y == point.y;
            }

            public override int GetHashCode()
            {
                int hashCode = 1502939027;
                hashCode = hashCode * -1521134295 + this.x.GetHashCode();
                hashCode = hashCode * -1521134295 + this.y.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                return string.Format("{{x:{0}, y:{1}}}", x.ToString(), y.ToString());
            }
            public static bool operator == (Point a, Point b)
            {
                return a.Equals(b);
            }
            public static bool operator !=(Point a, Point b)
            {
                return a.Equals(b);
            }
        }
        public struct Size
        {
            public int width;
            public int height;
            public Size(int width, int height)
            {
                this.width = width;
                this.height = height;
            }
            public override string ToString()
            {
                return string.Format("{{width:{0}, height:{1}}}", width.ToString(), height.ToString());
            }
        }
        [DllImport(DLL_NAME, EntryPoint = "WindowFromPoint")]
        public static extern IntPtr WindowFromPoint(Point Point);

        [DllImport(DLL_NAME, EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport(DLL_NAME, EntryPoint = "GetClassName")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);// 钩子委托声明
        [DllImport(DLL_NAME, EntryPoint = "SetWindowsHookEx")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr pInstance, int threadId);//安装钩子
        [DllImport(DLL_NAME, EntryPoint = "UnhookWindowsHookEx")]// 卸载钩子
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);

        [DllImport(DLL_NAME, EntryPoint = "CallNextHookEx")]
        public static extern int CallNextHookEx(IntPtr pHookHandle, int nCode, Int32 wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyMSG
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [DllImport(DLL_NAME, EntryPoint = "IsWindow")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport(DLL_NAME, EntryPoint = "MessageBox")]
        public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        [DllImport(DLL_NAME, EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport(DLL_NAME, EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hwndChild, IntPtr newParent);

        [DllImport(DLL_NAME, EntryPoint = "GetParent")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        //[DllImport(DLL_NAME, EntryPoint = "EnumDisplaySettings")]
        //public static extern bool EnumDisplaySettings(string lpszDeviceName, uint iModeNum, lpDevMode);

        public delegate IntPtr WindowLongCallBack(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(DLL_NAME, EntryPoint = "GetWindowLong")]
        public extern static IntPtr GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport(DLL_NAME, EntryPoint = "GetWindowLong")]
        public extern static IntPtr GetWindowLong(IntPtr hWnd, WindowsLongMessage nIndex);
        [DllImport(DLL_NAME, EntryPoint = "SetWindowLong")]
        public extern static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, WindowLongCallBack wndProc);
        [DllImport(DLL_NAME, EntryPoint = "SetWindowLong")]
        public extern static IntPtr SetWindowLong(IntPtr hWnd, WindowsLongMessage nIndex, WindowLongCallBack wndProc);
        [DllImport(DLL_NAME, EntryPoint = "CallWindowProc")]
        public extern static IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
