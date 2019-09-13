using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Threading;

namespace BuildServer.Helpers
{
    public class ProcessKiller
    {
        private readonly int delayInSeconds;
        private Timer _timer;

        public ProcessKiller(IConfiguration configuration)
        {
            delayInSeconds = int.Parse(configuration.GetSection("delayInSeconds").Value);
        }

        public void KillProcess(Process process)
        {
            TimerCallback killTimer = new TimerCallback(Kill);
            _timer = new Timer(killTimer, process, delayInSeconds * 1000, -1);
        }

        private void Kill(object process)
        {
            var p = process as Process;
            try
            {
                if (!p.HasExited)
                {
                    p.Kill();
                    _timer.Dispose();
                    Console.WriteLine("Process was killed");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Process stopped by itself");
            }
        }
    }
}
