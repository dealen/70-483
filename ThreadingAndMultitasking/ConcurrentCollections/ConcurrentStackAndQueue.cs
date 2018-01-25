using HelpersLibrary;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace ThreadingAndMultitasking.ConcurrentCollections
{
    public class ConcurrentStackAndQueue : IRun
    {
        public void Run()
        {
            StackExample();
        }

        private void StackExample()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var stack = new ConcurrentStack<int>();
            stack.Push(42);
            int result;
            if (stack.TryPop(out result))
                Console.WriteLine($"Popped {result}");
            stack.PushRange(new int[] { 1, 2, 3 });

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }
    }
}
