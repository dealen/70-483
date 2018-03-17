using HelpersLibrary;
using System;
using System.Reflection;

namespace ClassHierarchy
{
    public class OverridingAVirtualMethodtests : IRun
    {
        public void Run()
        {
            var derived = new Derived();
        }
    }

    class Base
    {
        protected virtual void Execute()
        {
            Console.WriteLine($"-----------OverridingAVirtualMethodtests");
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
        }
    }

    class Derived : Base
    {
        public Derived()
        {
            Execute();
        }

        protected override void Execute()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Log("Before executing");
            base.Execute();
            Log("After execution");
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


}
