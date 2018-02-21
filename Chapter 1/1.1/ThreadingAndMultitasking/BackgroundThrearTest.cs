using HelpersLibrary;
using System;
using System.Reflection;
using System.Threading;

namespace ThreadingAndMultitasking
{
    public class ThreadingClass : IRun
    {
        private void Counter()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(1000);
            }
        }

        private void CounterWithParameter(object count)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
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
