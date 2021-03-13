using System;
using System.Collections.Generic;
using System.Text;

namespace JxCode.Windows.Native
{
    public static partial class User32
    {
        /// <summary>
        /// Windows 使用的256个虚拟键码
        /// </summary>
        public enum VK_Keys
        {
            /// <summary>
            ///
            /// </summary>
            VK_LBUTTON = 0x1,
            /// <summary>
            ///
            /// </summary>
            VK_RBUTTON = 0x2,
            /// <summary>
            ///
            /// </summary>
            VK_CANCEL = 0x3,
            /// <summary>
            ///
            /// </summary>
            VK_MBUTTON = 0x4,
            /// <summary>
            ///
            /// </summary>
            VK_BACK = 0x8,
            /// <summary>
            ///
            /// </summary>
            VK_TAB = 0x9,
            /// <summary>
            ///
            /// </summary>
            VK_CLEAR = 0xC,
            /// <summary>
            ///
            /// </summary>
            VK_RETURN = 0xD,
            /// <summary>
            ///
            /// </summary>
            VK_SHIFT = 0x10,
            /// <summary>
            ///
            /// </summary>
            VK_CONTROL = 0x11,
            /// <summary>
            ///
            /// </summary>
            VK_MENU = 0x12,
            /// <summary>
            ///
            /// </summary>
            VK_PAUSE = 0x13,
            /// <summary>
            ///
            /// </summary>
            VK_CAPITAL = 0x14,
            /// <summary>
            ///
            /// </summary>
            VK_ESCAPE = 0x1B,
            /// <summary>
            ///
            /// </summary>
            VK_SPACE = 0x20,
            /// <summary>
            ///
            /// </summary>
            VK_PRIOR = 0x21,
            /// <summary>
            ///
            /// </summary>
            VK_NEXT = 0x22,
            /// <summary>
            ///
            /// </summary>
            VK_END = 0x23,
            /// <summary>
            ///
            /// </summary>
            VK_HOME = 0x24,
            /// <summary>
            ///
            /// </summary>
            VK_LEFT = 0x25,
            /// <summary>
            ///
            /// </summary>
            VK_UP = 0x26,
            /// <summary>
            ///
            /// </summary>
            VK_RIGHT = 0x27,
            /// <summary>
            ///
            /// </summary>
            VK_DOWN = 0x28,
            /// <summary>
            ///
            /// </summary>
            VK_Select = 0x29,
            /// <summary>
            ///
            /// </summary>
            VK_PRINT = 0x2A,
            /// <summary>
            ///
            /// </summary>
            VK_EXECUTE = 0x2B,
            /// <summary>
            ///
            /// </summary>
            VK_SNAPSHOT = 0x2C,
            /// <summary>
            ///
            /// </summary>
            VK_Insert = 0x2D,
            /// <summary>
            ///
            /// </summary>
            VK_Delete = 0x2E,
            /// <summary>
            ///
            /// </summary>
            VK_HELP = 0x2F,
            /// <summary>
            ///
            /// </summary>
            VK_0 = 0x30,
            /// <summary>
            ///
            /// </summary>
            VK_1 = 0x31,
            /// <summary>
            ///
            /// </summary>
            VK_2 = 0x32,
            /// <summary>
            ///
            /// </summary>
            VK_3 = 0x33,
            /// <summary>
            ///
            /// </summary>
            VK_4 = 0x34,
            /// <summary>
            ///
            /// </summary>
            VK_5 = 0x35,
            /// <summary>
            ///
            /// </summary>
            VK_6 = 0x36,
            /// <summary>
            ///
            /// </summary>
            VK_7 = 0x37,
            /// <summary>
            ///
            /// </summary>
            VK_8 = 0x38,
            /// <summary>
            ///
            /// </summary>
            VK_9 = 0x39,
            /// <summary>
            ///
            /// </summary>
            VK_A = 0x41,
            /// <summary>
            ///
            /// </summary>
            VK_B = 0x42,
            /// <summary>
            ///
            /// </summary>
            VK_C = 0x43,
            /// <summary>
            ///
            /// </summary>
            VK_D = 0x44,
            /// <summary>
            ///
            /// </summary>
            VK_E = 0x45,
            /// <summary>
            ///
            /// </summary>
            VK_F = 0x46,
            /// <summary>
            ///
            /// </summary>
            VK_G = 0x47,
            /// <summary>
            ///
            /// </summary>
            VK_H = 0x48,
            /// <summary>
            ///
            /// </summary>
            VK_I = 0x49,
            /// <summary>
            ///
            /// </summary>
            VK_J = 0x4A,
            /// <summary>
            ///
            /// </summary>
            VK_K = 0x4B,
            /// <summary>
            ///
            /// </summary>
            VK_L = 0x4C,
            /// <summary>
            ///
            /// </summary>
            VK_M = 0x4D,
            /// <summary>
            ///
            /// </summary>
            VK_N = 0x4E,
            /// <summary>
            ///
            /// </summary>
            VK_O = 0x4F,
            /// <summary>
            ///
            /// </summary>
            VK_P = 0x50,
            /// <summary>
            ///
            /// </summary>
            VK_Q = 0x51,
            /// <summary>
            ///
            /// </summary>
            VK_R = 0x52,
            /// <summary>
            ///
            /// </summary>
            VK_S = 0x53,
            /// <summary>
            ///
            /// </summary>
            VK_T = 0x54,
            /// <summary>
            ///
            /// </summary>
            VK_U = 0x55,
            /// <summary>
            ///
            /// </summary>
            VK_V = 0x56,
            /// <summary>
            ///
            /// </summary>
            VK_W = 0x57,
            /// <summary>
            ///
            /// </summary>
            VK_X = 0x58,
            /// <summary>
            ///
            /// </summary>
            VK_Y = 0x59,
            /// <summary>
            ///
            /// </summary>
            VK_Z = 0x5A,
            /// <summary>
            ///
            /// </summary>
            VK_STARTKEY = 0x5B,
            /// <summary>
            ///
            /// </summary>
            VK_CONTEXTKEY = 0x5D,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD0 = 0x60,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD1 = 0x61,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD2 = 0x62,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD3 = 0x63,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD4 = 0x64,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD5 = 0x65,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD6 = 0x66,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD7 = 0x67,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD8 = 0x68,
            /// <summary>
            ///
            /// </summary>
            VK_NUMPAD9 = 0x69,
            /// <summary>
            ///
            /// </summary>
            VK_MULTIPLY = 0x6A,
            /// <summary>
            ///
            /// </summary>
            VK_ADD = 0x6B,
            /// <summary>
            ///
            /// </summary>
            VK_SEPARATOR = 0x6C,
            /// <summary>
            ///
            /// </summary>
            VK_SUBTRACT = 0x6D,
            /// <summary>
            ///
            /// </summary>
            VK_DECIMAL = 0x6E,
            /// <summary>
            ///
            /// </summary>
            VK_DIVIDE = 0x6F,
            /// <summary>
            ///
            /// </summary>
            VK_F1 = 0x70,
            /// <summary>
            ///
            /// </summary>
            VK_F2 = 0x71,
            /// <summary>
            ///
            /// </summary>
            VK_F3 = 0x72,
            /// <summary>
            ///
            /// </summary>
            VK_F4 = 0x73,
            /// <summary>
            ///
            /// </summary>
            VK_F5 = 0x74,
            /// <summary>
            ///
            /// </summary>
            VK_F6 = 0x75,
            /// <summary>
            ///
            /// </summary>
            VK_F7 = 0x76,
            /// <summary>
            ///
            /// </summary>
            VK_F8 = 0x77,
            /// <summary>
            ///
            /// </summary>
            VK_F9 = 0x78,
            /// <summary>
            ///
            /// </summary>
            VK_F10 = 0x79,
            /// <summary>
            ///
            /// </summary>
            VK_F11 = 0x7A,
            /// <summary>
            ///
            /// </summary>
            VK_F12 = 0x7B,
            /// <summary>
            ///
            /// </summary>
            VK_F13 = 0x7C,
            /// <summary>
            ///
            /// </summary>
            VK_F14 = 0x7D,
            /// <summary>
            ///
            /// </summary>
            VK_F15 = 0x7E,
            /// <summary>
            ///
            /// </summary>
            VK_F16 = 0x7F,
            /// <summary>
            ///
            /// </summary>
            VK_F17 = 0x80,
            /// <summary>
            ///
            /// </summary>
            VK_F18 = 0x81,
            /// <summary>
            ///
            /// </summary>
            VK_F19 = 0x82,
            /// <summary>
            ///
            /// </summary>
            VK_F20 = 0x83,
            /// <summary>
            ///
            /// </summary>
            VK_F21 = 0x84,
            /// <summary>
            ///
            /// </summary>
            VK_F22 = 0x85,
            /// <summary>
            ///
            /// </summary>
            VK_F23 = 0x86,
            /// <summary>
            ///
            /// </summary>
            VK_F24 = 0x87,
            /// <summary>
            ///
            /// </summary>
            VK_NUMLOCK = 0x90,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_SCROLL = 0x91,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_1 = 0xBA,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_PLUS = 0xBB,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_COMMA = 0xBC,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_MINUS = 0xBD,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_PERIOD = 0xBE,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_2 = 0xBF,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_3 = 0xC0,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_4 = 0xDB,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_5 = 0xDC,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_6 = 0xDD,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_7 = 0xDE,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_8 = 0xDF,
            /// <summary>
            ///
            /// </summary>
            VK_ICO_F17 = 0xE0,
            /// <summary>
            ///
            /// </summary>
            VK_ICO_F18 = 0xE1,
            /// <summary>
            ///
            /// </summary>
            VK_OEM102 = 0xE2,
            /// <summary>
            ///
            /// </summary>
            VK_ICO_HELP = 0xE3,
            /// <summary>
            ///
            /// </summary>
            VK_ICO_00 = 0xE4,
            /// <summary>
            ///
            /// </summary>
            VK_ICO_CLEAR = 0xE6,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_RESET = 0xE9,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_JUMP = 0xEA,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_PA1 = 0xEB,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_PA2 = 0xEC,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_PA3 = 0xED,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_WSCTRL = 0xEE,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_CUSEL = 0xEF,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_ATTN = 0xF0,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_FINNISH = 0xF1,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_COPY = 0xF2,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_AUTO = 0xF3,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_ENLW = 0xF4,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_BACKTAB = 0xF5,
            /// <summary>
            ///
            /// </summary>
            VK_ATTN = 0xF6,
            /// <summary>
            ///
            /// </summary>
            VK_CRSEL = 0xF7,
            /// <summary>
            ///
            /// </summary>
            VK_EXSEL = 0xF8,
            /// <summary>
            ///
            /// </summary>
            VK_EREOF = 0xF9,
            /// <summary>
            ///
            /// </summary>
            VK_PLAY = 0xFA,
            /// <summary>
            ///
            /// </summary>
            VK_ZOOM = 0xFB,
            /// <summary>
            ///
            /// </summary>
            VK_NONAME = 0xFC,
            /// <summary>
            ///
            /// </summary>
            VK_PA1 = 0xFD,
            /// <summary>
            ///
            /// </summary>
            VK_OEM_CLEAR = 0xFE,
        }
    }
}
