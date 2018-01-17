using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.ConcurrentCollections
{
    public class ConcurrentBagTests : IRun
    {
        public void Run()
        {
            ConcurrentBagSample1();
            ConcurrentBagSampleEnumeration();
        }

        private void ConcurrentBagSample1()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            if (bag.TryPeek(out result))
                Console.WriteLine($"There is a next item: {result}");
        }

        private void ConcurrentBagSampleEnumeration()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }
    }
}
