using FunWithCSharp.Classes;
using HelpersLibrary;
using ProgramFlow;
using SynchronizingResources;
using System;
using ThreadingAndMultitasking;
using ThreadingAndMultitasking.AsyncAwait;
using ThreadingAndMultitasking.ConcurrentCollections;
using ThreadingAndMultitasking.ParallelClass;
using ThreadingAndMultitasking.PLINQ;
using ThreadingAndMultitasking.Tasks;
using UsingDelegates;

namespace FunWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructTest();
            //ReferenceTypeAssignment();
                        
            // 1.1

            //SimpleThreads();
            //SimpleTasks();

            //Parallel();
            //AsyncAndAwait();

            //PlinqSamples();

            //ConcurrentCollectionsSamples();
            //ConcurrentBagSamples();
            //ConcurrentStackAndQueueSamples();

            // 1.2

            //SynchResourcesSamplesTest();

            // 1.3

            //BooleanStatements();

            // 1.4

            UsingDelegatesBasics();

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        #region 1.1. Implementing Multithreading

        public static void ConcurrentStackAndQueueSamples()
        {
            IRun sq = new ConcurrentStackAndQueue();
            sq.Run();
        }

        public static void ConcurrentBagSamples()
        {
            IRun cb = new ConcurrentBagTests();
            cb.Run();
        }

        public static void ConcurrentCollectionsSamples()
        {
            IRun c = new ConcurrentCollectionsSamples();
            c.Run();
        }

        public static void PlinqSamples()
        {
            IRun pl = new PLinqSamples();
            pl.Run();
        }

        public static void AsyncAndAwait()
        {
            IRun aaa = new AsyncAndAwait();
            aaa.Run();
        }

        public static void Parallel()
        {
            IRun pl = new ParallelLoops();
            pl.Run();
        }

        public static void SimpleTasks()
        {
            IRun tb = new TasksBasics();
            tb.Run();

            IRun ct = new ChildTasks();
            ct.Run();

            IRun tfs = new TaskFactorySample();
            tfs.Run();
        }

        public static void SimpleThreads()
        {
            IRun tc = new ThreadingClass();
            //tc.ThreadMethod();

            IRun st = new StopingThread();
            //st.Run();

            IRun tsat = new ThreadStaticAttributeTest();
            //tsat.Run();

            IRun tld = new ThreadLocalData();
            tld.Run();

            IRun tpt = new ThreadPoolTests();
            tpt.Run();           
        }

        #endregion Implementing Multithreading

        #region 1.2. Managing Multithreading

        private static void SynchResourcesSamplesTest()
        {
            SynchResourcesSamples ss = new SynchResourcesSamples();
            ss.Run();
        }

        #endregion

        #region 1.3 Implement program flow

        public static void BooleanStatements()
        {
            IRun run = new ProgramFlowClass();
            run.Run();
        }

        #endregion

        #region 1.4 Create and implement events and delegates

        public static void UsingDelegatesBasics()
        {
            UsingDelegatesBasics a = new UsingDelegatesBasics();
            a.Run();

            IRun r = new MulticastDelegatesSample();
            r.Run();
        }

        #endregion

        public static void ReferenceTypeAssignment()
        {
            Console.WriteLine("Assigning reference types\n");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;

            p1.Display();
            p2.Display();

            p1.X = 100;

            Console.WriteLine("Changed p1.X to 100\n");
            p1.Display();
            p2.Display();
        }

        public static void StructTest()
        {
            Point point;
            point.X = 356;
            point.Y = 55;

            point.Display();

            point.Increment();
            point.Display();

            Point a;
            a.X = 22;
            //a.Display();

            // Operator NEW sprawia, że zmienne w strukturze będą miały domyślne wartości.
            // Inaczej nie da się zbudować i uruchomić projektu
            Point b = new Point();
            b.Y = 223;
            b.Display();

            Console.WriteLine("Assigning value types\n");
            Point p1 = new Point(10, 10);
            Point p2 = p1;
            p1.Display();
            p2.Display();

            Console.WriteLine("Changed p1.X to 100\n");
            p1.X = 100;
            p1.Display();
            p2.Display();

        }
    }
}
