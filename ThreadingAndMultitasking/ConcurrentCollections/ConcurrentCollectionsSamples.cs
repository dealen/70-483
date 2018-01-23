using HelpersLibrary;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;

namespace ThreadingAndMultitasking.ConcurrentCollections
{
    public class ConcurrentCollectionsSamples : IRun
    {
        public void Run()
        {
            UsingBlockingCollection();
            UsingBlockingCollection2();
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

        private void UsingBlockingCollection2()
        {
            var col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(v);
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
