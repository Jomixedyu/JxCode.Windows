using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public static class KeyboardUtil
    {
        public static void Click(User32.VK_Keys key)
        {
            User32.keybd_event(key, 0, User32.KeyEvent.down, 0);
            User32.keybd_event(key, 0, User32.KeyEvent.up, 0);
        }
    }
}
