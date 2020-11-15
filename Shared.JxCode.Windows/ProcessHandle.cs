using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace JxCode.Windows
{
    public class ProcessHandle : IDisposable
    {
        private readonly Process process;
        public Process Process { get => this.process; }

        public event Action<ProcessHandle> Exited;
        public event Action<string> Output;
        public event Action<string> Error;

        public string ProgramPath { get; }
        public string WorkDirectory { get; }
        public string Argument { get; }

        public ProcessHandle(string path, string workDir = null, string arg = null, ProcessWindowStyle style = ProcessWindowStyle.Normal)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                throw new ArgumentException();
            }
            if (workDir == null)
            {
                workDir = Path.GetDirectoryName(path);
            }

            this.ProgramPath = path;
            this.WorkDirectory = workDir;
            this.Argument = arg;

            ProcessStartInfo info = new ProcessStartInfo(path, arg)
            {
                WorkingDirectory = workDir,
                UseShellExecute = false,
                //RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = style,
            };
            Process process = new Process()
            {
                StartInfo = info,
            };
            process.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null)
                {
                    //程序结束
                    this.process.CancelErrorRead();
                    this.process.CancelOutputRead();
                    this.Exited?.Invoke(this);
                }
                else
                {
                    this.Output?.Invoke(e.Data);
                }
            };
            process.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    this.Error?.Invoke(e.Data);
                }
            };
            this.process = process;
        }

        public void Start()
        {
            this.process.Start();
            this.process.BeginOutputReadLine();
            this.process.BeginErrorReadLine();
        }
        public int StartWaitExit()
        {
            this.process.Start();
            this.process.BeginOutputReadLine();
            this.process.BeginErrorReadLine();
            this.process.WaitForExit();
            return this.process.ExitCode;
        }
        public void Shutdown()
        {
            if (!this.process.HasExited)
                this.process.Kill();
        }
        public void Dispose()
        {
            this.process?.Dispose();
        }
    }
}
