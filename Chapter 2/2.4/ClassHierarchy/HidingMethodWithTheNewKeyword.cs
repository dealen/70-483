using HelpersLibrary;
using System;

namespace ClassHierarchy
{
    public class HidingMethodWithTheNewKeyword : IRun
    {
        public void Run()
        {
            Base2 b = new Base2();
            b.Execute();
            Derived2 d = new Derived2();
            d.Execute();
        }
    }

    class Base2
    {
        public void Execute() { Console.WriteLine($"Base.Execute()"); }
    }

    class Derived2 : Base2
    {
        public new void Execute() { Console.WriteLine($"Derived.Execute()"); }
    }
}
