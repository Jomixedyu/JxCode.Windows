# JxCode.Windows
![](https://img.shields.io/github/license/JomiXedYu/JxCode.Windows?style=for-the-badge)
![](https://img.shields.io/github/v/release/JomiXedYu/JxCode.Windows?style=for-the-badge)
![](https://img.shields.io/github/release-date/JomiXedYu/JxCode.Windows?style=for-the-badge)

基于Win32API编写的C#windows操作类库。拥有窗体控制、鼠标键盘的模拟、任务栏进度条、托盘等工具，可以使用在控制台、链接库、以及Unity等windows平台的框架下。 

## Contents
- [JxCode.Windows](#jxcodewindows)
  - [Contents](#contents)
  - [如何使用](#如何使用)
  - [Win32API](#win32api)
  - [WindowsForm](#windowsform)
  - [App](#app)
  - [FileDialog](#filedialog)
  - [INI配置文件读写](#ini配置文件读写)
  - [KeyboardUtil](#keyboardutil)
  - [MCIPlayer](#mciplayer)
  - [MessageBox](#messagebox)
  - [TaskbarProgress](#TaskbarProgress)
  - [MouseUtil](#mouseutil)
  - [NotifyIcon](#notifyicon)
  - [ProcessHandle](#processhandle)
  - [RegeditConfiguration](#RegeditConfiguration)
  - [拓展工具](#拓展工具)

## 如何使用

两种方法：

- 直接将`Shared.JxCode.Windows`共享项目添加至解决方案并引用。
- 将`JxCode.Windows`项目编译成dll后，在项目中引用。

## Win32API
封装了一些常用的API以及Enum。API来源于：
- Kernel32
- Shell32
- User32
- Winmm
- comdlg32

可以在Native文件夹中找到，命名空间为`JxCode.Windows.Native`。

## WindowsForm
封装了窗体为WindowsForm对象，实现了一些Windows窗体控制与模拟的函数
- 获取窗体句柄
- 设置获取窗体标题
- 设置获取窗体类名
- 设置获取窗体大小与位置
- 设置获取窗体父对象
- 获取所有子窗体
- 设置窗体小图标
- 设置窗体置顶与还原
- 最小化、最大化、还原操作
- 设置窗体为焦点
- 发送粘贴消息到窗体
- 设置窗体激活状态（是否可用）
- 设置获取窗体外观

可以通过多种工厂函数创建WindowsForm对象:
- 从一个句柄创建
- 搜寻一个窗口标题创建
- 使用一个坐标来创建
- 从当前鼠标位置指向的窗体创建
- 从PID创建
- 从当前程序的PID创建
- 从调用线程的活动窗口创建

## App
可以获取一个程序运行时的一些基础状态。
- Path : 程序运行的工作路径
- BasePath : 程序所在路径
- FullPath : Exe的完整路径
- EXEName : Exe的名字（不含扩展名）
- PrevInstance : 是否有程序实例在运行

## FileDialog
打开文件与保存文件对话框，使用`comdlg32`导入api，封装后只对外暴露两个方法：
```C#
public static string OpenFileDialog(
    string dirPath, 
    string filter,
    string title = "OpenFileDialog",
    string defaultFilename = "");
```
```C#
public static string SaveFileDialog(
    string dirPath,
    string filter = "All(*.*)|*.*",
    string title = "SaveFileDialog",
    string defaultFilename = "")
```
它们都返回一个string，如果打开/保存成功，返回文件完整路径，否则为null。  


## INI配置文件读写
IniHelper文件中有两个类，分别是：  
- INIFile
- INISection

在`JxCode.Windows.Native`导入了API，并封装了`Kernel32.WritePrivateProfileString`和`Kernel32.GetPrivateProfileString`。

使用构造`public INIFile(string filepath)`创建INI对象。
```C#
INIFile inifile = new INIFile("a.ini");
INISection section = inifile["section"];
section.SetValue("k","v");
string v = section.GetValue("k");
```

## KeyboardUtil
键盘模拟
```C#
KeyboardUtil.Click(JxCode.Windows.Native.User32.VK_Keys.VK_W);
```
模拟`W`键按下

## MCIPlayer
使用MCI来播放音频或者视频

## MessageBox
使用`User32`中导出的函数，还原了`MessageBox`, `MessageBoxButtons`, `DialogResult`。
```C#
DialogResult r = MessageBox.Show("text", "caption", MessageBoxButtons.OkCancel);
```

## TaskbarProgress
设置windows任务栏进度条的状态的进度。  
可以使用WindowsForm类中函数，从当前进程中获取窗体对象。
```C#
var wf = WindowsForm.CreateFromCurrentPid();
TaskbarProgress.SetState(wf, TaskbarProgress.TaskbarStates.Normal);
TaskbarProgress.SetValue(wf, 50, 100);
```

## MouseUtil
- 获取与设置鼠标位置
- 模拟点击

## NotifyIcon
托盘按钮

## ProcessHandle
运行程序的一个句柄，可以方便的重定向输入输出流，设置程序响应与结束的回调，或终结程序。

## RegeditConfiguration
快速简洁的注册表配置工具类  
注册表的位置在`HKCU/Software/当前执行的程序集名字`。

```C#
static string GetSetting(
    string key, 
    string appName = null);
```
```C#
static void SetSetting(
    string key, 
    string value, 
    string appName = null)
```
当appName为null时，则默认使用当前运行程序集的名字作为配置名。
## 拓展工具
Java信息获取（获取本机安装的所有Java信息）
