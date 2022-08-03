using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace TestSample
{
    public class LoggerService
    {
        public static void Debug(string msg, [CallerMemberName] string name = null,
            [CallerFilePath] string filePath = null)
        {
#if DEBUG
            var output = $"{ThreadNameOrId()}-{DateTime.Now:O}|{filePath}|{name}|{msg}";
            System.Diagnostics.Debug.WriteLine(output);
#endif
        }

        private static string ThreadNameOrId()
        {
            var threadName = $"ThreadName: {Thread.CurrentThread.Name}";
            if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
            {
                threadName = $"ThreadId: {Thread.CurrentThread.ManagedThreadId.ToString()}";
            }

            return threadName;
        }
    }
}