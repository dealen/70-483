using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

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
