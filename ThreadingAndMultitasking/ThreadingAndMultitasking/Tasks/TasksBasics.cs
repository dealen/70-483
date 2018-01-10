using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.Tasks
{
    public class TasksBasics : IRun
    {
        public void Run()
        {
            SimpleContinueWithSample();
            ContinueWithTaskParameters();
            SimplaTasksWithWaitAll();
            SimplaTasksWithWaitAny();
        }

        /*
         * The ContinueWith method has a couple of overloads that you can use to configure when the continuation will run. 
         * This way you can add different continuation methods that will run when an exception happens, the Task is canceled, 
         * or the Task completes successfully. Listing 1-11 shows how to do this.
         * */

        private void SimpleContinueWithSample()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Console.WriteLine($"{StaticValues.MethodHeader} {m.Name}");
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

        private void ContinueWithTaskParameters()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Console.WriteLine($"{StaticValues.MethodHeader} {m.Name}");
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
        
        /// <summary>
        /// Wszystkie taski są uruchamiane w jednym momencie, czyli działanie funkcji trwa 1000 ms,
        /// a nie 3000.
        /// </summary>
        private void SimplaTasksWithWaitAll()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Console.WriteLine($"{StaticValues.MethodHeader} {m.Name}");
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });
            Task.WaitAll(tasks);            
        }        


        private void SimplaTasksWithWaitAny()
        {
            MethodBase m = MethodBase.GetCurrentMethod();
            Console.WriteLine($"{StaticValues.MethodHeader} {m.Name}");
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("3");
                return 3;
            });


            //Task.WaitAny(tasks);

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];

                Console.WriteLine($"Result from completed task: {completedTask.Result}");

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }        
    }
}
