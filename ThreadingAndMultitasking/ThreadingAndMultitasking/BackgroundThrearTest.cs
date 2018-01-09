using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking
{
    public class ThreadingClass : IRun
    {
        private void Counter()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        private void CounterWithParameter(object count)
        {
            int cnt = int.Parse(count.ToString());
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        public void Run()
        {

            Thread t = new Thread(new ParameterizedThreadStart(CounterWithParameter))
            {
                IsBackground = false
            };
            t.Start(15);
        }
    }
}
