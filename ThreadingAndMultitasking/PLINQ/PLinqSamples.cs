using HelpersLibrary;
using System;
using System.Linq;
using System.Reflection;

namespace ThreadingAndMultitasking.PLINQ
{
    public class PLinqSamples : IRun
    {
        public void Run()
        {
            NumbersPLinq();
            NumbersPLinq2();
            ForAllPlinq();
            PLinqAgregateExceptions();
        }

        private void NumbersPLinq()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var numbers = Enumerable.Range(0, 15);
            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult)
            {
                Console.WriteLine($" {i}");
            }
        }

        private void NumbersPLinq2()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).AsSequential();

            foreach (int i in parallelResult)
            {
                Console.WriteLine($" {i}");
            }
        }

        private void ForAllPlinq()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var numbers = Enumerable.Range(0, 20);

            var pRedult = numbers.AsParallel().Where(i => i % 2 == 0);

            pRedult.ForAll(e => Console.WriteLine(e));
        }

        private void PLinqAgregateExceptions()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var numbers = Enumerable.Range(0, 20);

            try
            {
                var pResult = numbers.AsParallel().Where(x => IsEven(x));
                pResult.ForAll(x => Console.WriteLine(x));
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"There were {e.InnerExceptions.Count} exceptions.");
            }
        }

        private bool IsEven(int i)
        {
            return i % 10 == 0 ? throw new ArgumentException("i") : i % 2 == 0;
        }
    }
}
