using HelpersLibrary;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ThreadingAndMultitasking.Tasks
{
    public class ChildTasks : IRun
    {
        public void Run()
        {
            SimpleChildTasks();
        }

        private void SimpleChildTasks()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            var finalTask = parent.ContinueWith(
                    parentTask =>
                    {
                        foreach (var i in parentTask.Result)
                        {
                            Console.WriteLine($"Child task number: {i}");
                        }
                    }
                );

            finalTask.Wait();
        }
    }
}
