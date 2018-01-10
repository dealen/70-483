using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.ParallelClass
{
    public class ParallelLoops : IRun
    {
        public void Run()
        {
            SimpleParallelTest();
            ParallelUsingBreakes();
        }

        private void SimpleParallelTest()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }

        public void ParallelUsingBreakes()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine($"Breaking loop");
                    loopState.Break();
                }
                return;
            });
        }
    }
}
