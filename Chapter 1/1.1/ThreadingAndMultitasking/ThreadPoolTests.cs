using HelpersLibrary;
using System;
using System.Threading;

namespace ThreadingAndMultitasking
{
    public class ThreadPoolTests : IRun
    {
        public void Run()
        {
            ThreadPool.QueueUserWorkItem((s) => {
                Console.WriteLine($"Working on a thread from threadpool");
            });
        }
    }
}
