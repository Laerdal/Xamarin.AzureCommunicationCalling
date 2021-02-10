using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AzureCommunicationVideoTest
{
    public class Logger
    {
        public static void Debug(string msg, [CallerMemberName] string name = null)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"{ThreadNameOrId()} - {DateTime.Now:O} {name}: {msg}");
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