using HelpersLibrary;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ThreadingAndMultitasking.Tasks
{
    public class TaskFactorySample : IRun
    {
        public void Run()
        {
            Console.WriteLine($"---TaskFactory");
            SimpleFactory();
        }

        private void SimpleFactory()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];

                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => result[0] = 0);
                tf.StartNew(() => result[1] = 1);
                tf.StartNew(() => result[2] = 2);

                return result;
            });


            var finalTask = parent.ContinueWith(
                    parentTask =>
                    {
                        foreach (int i in parentTask.Result)
                            Console.WriteLine($"Child Task from TakasFactory number: {i}");
                    }
                );

            finalTask.Wait();
        }
    }
}
