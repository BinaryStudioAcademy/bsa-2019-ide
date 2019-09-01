using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace BuildServer.Helpers
{
    public class ProcessKiller
    {
        private readonly int delayInSeconds;
        public ProcessKiller(IConfiguration configuration)
        {
            delayInSeconds = int.Parse(configuration.GetSection("delayInSeconds").Value);
        }
        Timer KillProc;
        public void KillProcess(Process process)
        {
            TimerCallback killTimer = new TimerCallback(Kill);

            KillProc = new Timer(killTimer, process, delayInSeconds * 1000, -1);
        }

        private void Kill(object process)
        {
            var p = process as Process;
            try
            {
                var time = p.StartTime;
                if (!p.HasExited)
                {
                    p.Kill();
                    Console.WriteLine("Process was killed");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("process dont start");
            }
        }
    }
}
