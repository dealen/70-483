using HelpersLibrary;
using System;
using System.Reflection;

namespace ValueAndReferenceTypes
{
    public class TestValueTypes
    {
        public TestValueTypes()
        {
            PointStruct p = new PointStruct(4, 5);
            Console.WriteLine($"This is struct object in constructor, before passing to method: x: {p.x} y: {p.y}");
            TestIfByPassingToMethodWeModifyTheSameObject(p);
            Console.WriteLine($"This is struct object in constructor, after passing to method: x: {p.x} y: {p.y}");
        }

        public void TestIfByPassingToMethodWeModifyTheSameObject(PointStruct p)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            p.x = 15;
            Console.WriteLine($"This is the same struct object passed to method: x: {p.x} y: {p.y}");
        }
    }
}
