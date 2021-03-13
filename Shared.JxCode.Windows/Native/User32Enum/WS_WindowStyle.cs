using System;
using System.Collections.Generic;
using System.Text;

namespace JxCode.Windows.Native
{
    public static partial class User32
    {
        /// <summary>
        /// Windows 窗口样式
        /// </summary>
        [Flags]
        public enum WS_WindowStyle : uint
        {
            /// <summary>
            ///
            /// </summary>
            WS_OVERLAPPED = 0x00000000,
            /// <summary>
            ///
            /// </summary>
            WS_POPUP = 0x80000000,
            /// <summary>
            ///
            /// </summary>
            WS_CHILD = 0x40000000,
            /// <summary>
            ///
            /// </summary>
            WS_MINIMIZE = 0x20000000,
            /// <summary>
            ///
            /// </summary>
            WS_VISIBLE = 0x10000000,
            /// <summary>
            ///
            /// </summary>
            WS_DISABLED = 0x08000000,
            /// <summary>
            ///
            /// </summary>
            WS_CLIPSIBLINGS = 0x04000000,
            /// <summary>
            ///
            /// </summary>
            WS_CLIPCHILDREN = 0x02000000,
            /// <summary>
            ///
            /// </summary>
            WS_MAXIMIZE = 0x01000000,
            /// <summary>
            ///
            /// </summary>
            WS_CAPTION = 0x00C00000,
            /// <summary>
            ///
            /// </summary>
            WS_BORDER = 0x00800000,
            /// <summary>
            ///
            /// </summary>
            WS_DLGFRAME = 0x00400000,
            /// <summary>
            ///
            /// </summary>
            WS_VSCROLL = 0x00200000,
            /// <summary>
            ///
            /// </summary>
            WS_HSCROLL = 0x00100000,
            /// <summary>
            ///
            /// </summary>
            WS_SYSMENU = 0x00080000,
            /// <summary>
            ///
            /// </summary>
            WS_THICKFRAME = 0x00040000,
            /// <summary>
            ///
            /// </summary>
            WS_GROUP = 0x00020000,
            /// <summary>
            ///
            /// </summary>
            WS_TABSTOP = 0x00010000,
            /// <summary>
            ///
            /// </summary>
            WS_MINIMIZEBOX = 0x00020000,
            /// <summary>
            ///
            /// </summary>
            WS_MAXIMIZEBOX = 0x00010000,
            /// <summary>
            ///
            /// </summary>
            WS_TILED = WS_OVERLAPPED,
            /// <summary>
            ///
            /// </summary>
            WS_ICONIC = WS_MINIMIZE,
            /// <summary>
            ///
            /// </summary>
            WS_SIZEBOX = WS_THICKFRAME,
            /// <summary>
            ///
            /// </summary>
            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
            /// <summary>
            ///
            /// </summary>
            WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                    WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
            /// <summary>
            ///
            /// </summary>
            WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
            /// <summary>
            ///
            /// </summary>
            WS_CHILDWINDOW = (WS_CHILD)
        }
    }
}
