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

            Task<int> t1 = Task.Run(() =>
            {
                return 43;
            });

            Console.WriteLine("\nThis sample returns a value from Task<int>");
            Console.WriteLine($"Result from current Task<int> = {t1.Result}");

            Task<int> t2 = Task.Run(() =>
            {
                return 43;
            }).ContinueWith((task) =>
            {
                return task.Result * 2;
            });

            Console.WriteLine("\nThis sample returns a value from Task<int> with Continuation Task");
            Console.WriteLine($"Result from current Task<int> (result * 2) = {t2.Result}");
            
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
