using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizingResources
{
    public class SynchResourcesSamples : IRun
    {
        public void Run()
        {
            ThreadsWithoutControll();
            LockingThreads();
            CreatingADeadlock();
            UsingInterlockedClass();
            CompareAndExchangeAsANonatomicOperation();
            UsingACancellationToken();
            //UsingACancellationTokenWithException();
            //UsingACancellationTokenWithContinuationtask();
            TaskWithTimeout();
        }

        private void ThreadsWithoutControll()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    n++;
                }
            });


            for (int i = 0; i < 1000000; i++)
            {
                n--;
            }

            up.Wait();
            Console.WriteLine(n);
        }

        private void LockingThreads()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            int n = 0;

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                        n++;
                }
            });
            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                    n--;
            }

            up.Wait();
            Console.WriteLine(n);
        }

        private void CreatingADeadlock()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                Thread.Sleep(1000);
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                        Console.WriteLine("Lockad A and B");
                }
            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B");
                }
            }

            up.Wait();
        }

        private void UsingInterlockedClass()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }

            up.Wait();
            Console.WriteLine(n);
        }

        static int value = 1;
        private void CompareAndExchangeAsANonatomicOperation()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    // Removing the following line will change output
                    //Thread.Sleep(1000);
                    var newValue = 2;
                    var compareTo = value;
                    Interlocked.CompareExchange(ref value, newValue, compareTo);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() =>
            {
                var newValue = 3;
                var compareTo = value;
                Interlocked.CompareExchange(ref value, newValue, compareTo);
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
        }

        private void UsingACancellationToken()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            source.Cancel();
        }

        private void UsingACancellationTokenWithException()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token);

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                source.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
        }

        private void UsingACancellationTokenWithContinuationtask()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                t.Exception.Handle((e) => true);
                Console.WriteLine("You have canceled the task");

            }, TaskContinuationOptions.OnlyOnCanceled);
        }

        private void TaskWithTimeout()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Task longRunning = Task.Run(() => 
            {
                Thread.Sleep(10000);
            });

            int index = Task.WaitAny(new[] { longRunning }, 1000);

            if (index == -1)
                Console.WriteLine("Task timed out");
        }
    }
}
