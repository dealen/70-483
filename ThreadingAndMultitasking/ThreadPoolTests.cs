using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

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
