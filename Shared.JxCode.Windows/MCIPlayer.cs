using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using JxCode.Windows.Native;

namespace JxCode.Windows
{
    public class MCIPlayer
    {
        public string FilePath { get; set; }
        private string alias = "ll";
        public IntPtr Handle { get; set; }

        public void Play(bool isLoop = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("open {0} alias {1}", this.FilePath, this.alias);
            if (this.Handle != IntPtr.Zero)
                sb.AppendFormat(" parent {0} style child", this.Handle, ((long)WindowStyle.WS_CHILD).ToString());

            ExecuteCommand(sb.ToString());
            string playCmd = "play " + this.alias + (isLoop ? " repeat" : string.Empty);
            ExecuteCommand(playCmd);
        }
        public void Stop()
        {
            ExecuteCommand(string.Format("stop {0}", this.alias));
        }

        public void SetSize(int x, int y, int width, int height)
        {
            string cmd = string.Format("put {0} window at {1} {2} {3} {4}",
                this.alias, x, y, width, height);
            try
            {
                ExecuteCommand(cmd);
            }
            catch (Exception)
            {
            }
        }

        public static void ExecuteCommand(string cmd)
        {
            var err = Winmm.mciSendString(cmd, null, 0, 0);

            if (err != 0)
            {
                StringBuilder buf = new StringBuilder(256);
                Winmm.mciGetErrorString(err, buf, 256);
                string errStr = buf.ToString();
                throw new MCIException(string.Format("ErrorCode: {0} ,Info: {1}", err.ToString(), errStr));
            }
        }

        public static void PlayMusic(string musicPath, bool isLoop)
        {
            try
            {
                ExecuteCommand("close __MUSIC");
            }
            catch (Exception)
            {
            }

            ExecuteCommand("open \"" + musicPath + "\" alias __MUSIC");
            ExecuteCommand("play __MUSIC" + (isLoop ? " repeat" : string.Empty));


        }
        public static void StopMusic(string musicPath)
        {
            ExecuteCommand("stop __MUSIC");
        }


        public class MCIException : ApplicationException
        {
            public MCIException(string errMsg) : base(errMsg)
            {

            }
        }
    }
}
