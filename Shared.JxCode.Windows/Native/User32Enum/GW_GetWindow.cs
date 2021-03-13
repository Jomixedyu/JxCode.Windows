namespace JxCode.Windows.Native
{
    public static partial class User32
    {
        public enum GW_GetWindow : int
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
        }
    }
}
