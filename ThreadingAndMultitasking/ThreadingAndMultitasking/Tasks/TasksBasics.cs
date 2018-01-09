using System;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.Tasks
{
    public class TasksBasics : IRun
    {
        public void Run()
        {
            Task t = Task.Run(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write('*');
                }
            });
            t.Wait();
        }
    }
}
