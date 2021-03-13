using JxCode.Windows.Native;
using MouseEventType = JxCode.Windows.Native.User32.MOUSEEVENTF_MouseEventType;

namespace JxCode.Windows
{
    /// <summary>
    /// 鼠标操作类
    /// </summary>
    public static class MouseUtil
    {
        public static void SetCursorPosition(int x , int y)
        {
            User32.SetCursorPos(x, y);
        }
        public static void SetToCenter()
        {
            User32.mouse_event(MouseEventType.MOUSEEVENTF_MOVE | MouseEventType.MOUSEEVENTF_ABSOLUTE, 32768, 32768, 0, 0);
        }
        public static void LeftClick()
        {
            User32.mouse_event(MouseEventType.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            User32.mouse_event(MouseEventType.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void RightClick()
        {
            User32.mouse_event(MouseEventType.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            User32.mouse_event(MouseEventType.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public static void MiddleDown()
        {
            User32.mouse_event(MouseEventType.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
            User32.mouse_event(MouseEventType.MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }
        public static void MiddleWhell(int count)
        {
            User32.mouse_event(MouseEventType.MOUSEEVENTF_WHEEL, 0, 0, count, 0);
        }

        public static void MoveTo(User32.Point pos, float speed)
        {

        }

        public static User32.Point GetMousePosition()
        {
            User32.Point p = new User32.Point();
            User32.GetCursorPos(ref p);
            return p;
        }
    }

}
