using AboutString;
using ClassHierarchy;
using EnforcingEncapsulation;
using EventsTests;
using Exceptions;
using FunWithCSharp.Classes;
using HelpersLibrary;
using LinqTests;
using ProgramFlow;
using ReflectionTests;
using ReflectionTests.CodeDOM;
using ReflectionTests.ExpressionTrees;
using SecureStrings;
using SerializationTests;
using SymetricAndAsymetricEncryptionTests;
using SynchronizingResources;
using System;
using ThreadingAndMultitasking;
using ThreadingAndMultitasking.AsyncAwait;
using ThreadingAndMultitasking.ConcurrentCollections;
using ThreadingAndMultitasking.ParallelClass;
using ThreadingAndMultitasking.PLINQ;
using ThreadingAndMultitasking.Tasks;
using UsingDelegates;
using UsingLambda;
using ValidateApplicationInputTests;
using ValueAndReferenceTypes;

namespace FunWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructTest();
            //ReferenceTypeAssignment();

            //FirstChapter();
            //SecondChapter();
            //ThirdChapter();

            FourthChapter();

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        private static void FirstChapter()
        {
            // 1.1

            SimpleThreads();
            SimpleTasks();

            Parallel();
            AsyncAndAwait();

            PlinqSamples();

            ConcurrentCollectionsSamples();
            ConcurrentBagSamples();
            ConcurrentStackAndQueueSamples();

            // 1.2

            SynchResourcesSamplesTest();

            // 1.3

            BooleanStatements();

            // 1.4

            UsingDelegatesBasics();

            UsingLambdas();

            EventsCalls();

            // 1.5

            Exceptionhandling();

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

            IRun r1 = new CovarianceContrvarianceAndDelegates();
            r1.Run();
        }

        public static void UsingLambdas()
        {
            IRun run = new UsingLambdaExpressions();
            run.Run();
        }

        public static void EventsCalls()
        {
            IRun run = new EventsBasics();
            run.Run();

            IRun evt = new CustomEventHandler();
            evt.Run();

            IRun custom = new CustomEventAccess();
            custom.Run();

            IRun exp = new EventsWithExceptions();
            exp.Run();

            IRun eh = new EventsWithExceptionhandling();
            eh.Run(); 
        }

        #endregion

        #region 1.5 Exceptions

        private static void Exceptionhandling()
        {
            IRun ex = new ExceptionsBasics();
            //ex.Run();

            ex = new ExceptionWithFinally();
            //ex.Run();

            ex = new ExceptionInspecting();
            //ex.Run();

            ex = new ThrowingExceptions();
            //ex.Run();

            ex = new DispatcherThrowMethod();
            ex.Run();
        }

        #endregion

        private static void SecondChapter()
        {
            // 2.1
            ValueAndReferenceTypesTests();

            //2.3
            EnforcingEncapsulationTests();

            //2.4
            ClassHierarchy();

            //2.5
            ReflectionTests();

            //2.6

            //2.7
            StringOperations();
        }

        #region 2.1 Create types

        private static void ValueAndReferenceTypesTests()
        {
            IRun run = new ValueAndReferenceTypesClass();
            run.Run();
        }

        #endregion

        #region 2.3 Enforcing Encapsulation
        
        private static void EnforcingEncapsulationTests()
        {
            IRun run = new ImplicitInterfaceImplementation();
            run.Run();
        }

        #endregion

        #region 2.4 Create and implement class hierarchy

        private static void ClassHierarchy()
        {
            IRun run = new InstatnionatingConcreteTypeToInterface();
            run.Run();

            run = new CreatingABaseClass();
            run.Run();

            run = new OverridingAVirtualMethodtests();
            run.Run();

            run = new HidingMethodWithTheNewKeyword();
            run.Run();

            run = new AbstractClassesTest();
            run.Run();
        }

        #endregion

        #region 2.5 Reflection

        private static void ReflectionTests()
        {
            IRun run = new UsingTypeOfTests();
            run.Run();

            run = new InformationAboutBaseTypesAndInterfacesOfClass();
            run.Run();

            run = new CreatingTypesWithRefelction();
            run.Run();

            run = new ReflectionViewingClassMembers();
            run.Run();

            run = new GettingMembersOfGenericClasses();
            run.Run();

            run = new DynamicAndStaticCoupling();
            run.Run();

            run = new UsingRefAndOutInReflection();
            run.Run();

            run = new ViewingGenericClassesWithReflection();
            run.Run();

            run = new DelegatesToEnhancePerformance();
            run.Run();

            run = new AccessTononPublicMembers();
            run.Run();

            run = new InvokingGenericMethod();
            run.Run();

            run = new CallingMembersOfGenericInterface();
            run.Run();

            run = new InspectingAssemblyWithCustomPluginInterface();
            run.Run();

            run = new LoadingAssemblyInfo();
            run.Run();

            run = new GeneratingHelloWorld();
            run.Run();

            run = new CreatingHelloWorld();
            run.Run();
        }

        #endregion

        #region 2.6 Manage the object life cycle



        #endregion

        #region 2.5 String

        private static void StringOperations()
        {
            IRun run = new UsingTestWriterAndStringWriter();
            run.Run();
        }

        #endregion

        private static void ThirdChapter()
        {
            ParsingTryParsingAndConverting();
            UsingRegularExp();
            ValidatingXMLJSONTests();
            SymetricAndAsymetricEncryptionTest();
            ManagingAssemblies();
        }

        #region 3.1 ValidateApplicationInput

        private static void ParsingTryParsingAndConverting()
        {
            IRun run = new ParteTryParseConvertTests();
            run.Run();
        }

        private static void UsingRegularExp()
        {
            IRun run = new UsingRedularExpressions();
            run.Run();
        }

        private static void ValidatingXMLJSONTests()
        {
            IRun run = new ValidatingJSONandXML();
            run.Run();
        }

        #endregion

        #region 3.2. Perform symetric and asymetric encryption

        private static void SymetricAndAsymetricEncryptionTest()
        {
            IRun run = new BasicEncryptionAndDecryption();
            run.Run();

            run = new UsingPublicAndprivateKeyToEncryptAdnDecryptData();
            run.Run();

            run = new UsingHashingTest();
            run.Run();

            run = new ManagingAndCreatingCertificates();
            run.Run();
        }

        #endregion

        #region 3.3 Manage assemblies

        private static void ManagingAssemblies()
        {
            IRun run = new SecureStringsTest();
            run.Run();
        }

        #endregion

        private static void FourthChapter()
        {
            UsingLinqQueries();
            SerializationAndDeserialization();
        }

        #region 4.3 LINQ

        private static void UsingLinqQueries()
        {
            IRun run = new LinqFunctionsTests();
            run.Run();

            run = new UsingLinqWithXML();
            run.Run();
        }

        #endregion

        #region 4.4 Serialization and deserialization

        private static void SerializationAndDeserialization()
        {
            IRun run = new UsingXMLSerializer();
            run.Run();

            run = new BinarySerialization();
            run.Run();
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
            Point b = new Point
            {
                Y = 223
            };
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
