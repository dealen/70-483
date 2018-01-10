using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking
{
    public class ThreadLocalData : IRun
    {
        public ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public void Run()
        {
            new Thread(() => 
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine($"Thread A: {i}");
                }
            }).Start();
            new Thread(() => 
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine($"Thread B: {i}");
                }
            }).Start();
        }
    }
}
