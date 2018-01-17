using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.ConcurrentCollections
{
    public class ConcurrentCollectionsSamples : IRun
    {
        public void Run()
        {
            UsingBlockingCollection();
        }

        private void UsingBlockingCollection()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    var s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }
    }
}
