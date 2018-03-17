using HelpersLibrary;
using System;
using System.Reflection;

namespace ValueAndReferenceTypes
{
    public class TestReferenceTypes
    {
        public TestReferenceTypes()
        {
            PointClass p = new PointClass(4, 5);
            Console.WriteLine($"This is object in constructor, before passing to method: x: {p.x} y: {p.y}");
            TestIfByPassingToMethodWeModifyTheSameObject(p);
            Console.WriteLine($"This is object in constructor, after passing to method: x: {p.x} y: {p.y}");
        }

        public void TestIfByPassingToMethodWeModifyTheSameObject(PointClass p)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            p.x = 15;
            Console.WriteLine($"This is the same object passed to method: x: {p.x} y: {p.y}");
        }
    }
}
