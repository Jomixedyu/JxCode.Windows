using System;
using System.Collections.Generic;
using System.Text;

namespace JxCode.Windows.Native
{
    public enum MouseEventType : int
    {
        /// <summary>
        /// 移动鼠标 
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,
        /// <summary>
        /// 模拟鼠标左键按下 
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        /// <summary>
        /// 模拟鼠标左键抬起 
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,
        /// <summary>
        /// 模拟鼠标右键按下 
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        /// <summary>
        /// 模拟鼠标右键抬起 
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,
        /// <summary>
        /// 模拟鼠标中键按下 
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        /// <summary>
        /// 模拟鼠标中键抬起 
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        /// <summary>
        /// 标示是否采用绝对坐标
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,
        /// <summary>
        /// 模拟鼠标滚轮滚动操作，必须配合dwData参数
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,
    }
}
