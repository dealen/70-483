using HelpersLibrary;
using System;
using System.Reflection;

namespace UsingDelegates
{
    public class UsingDelegatesBasics : IRun
    {
        public void Run()
        {
            UseDelegate();
        }

        public delegate int Calculate(int x, int y);

        public int Add(int x, int y)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            return x + y;
        }
        public int Multiply(int x, int y)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            return x * y;
        }

        public void UseDelegate()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Calculate calc = Add;
            Console.WriteLine(calc(4, 5));

            calc = Multiply;
            Console.WriteLine(calc(4, 5));
        }

    }
}
