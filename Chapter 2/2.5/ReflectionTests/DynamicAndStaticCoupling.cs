using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class DynamicAndStaticCoupling : IRun
    {
        public void Run()
        {
            DynamicAndStaticCouplingExample();
        }

        private void DynamicAndStaticCouplingExample()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Console.WriteLine("---Static coupling:");
            string s = "Hello";
            int lengthOfS = s.Length;
            Console.WriteLine($"string s = \"Hello\";");
            Console.WriteLine($"int lengthOfS = s.Length; - {lengthOfS}");

            Console.WriteLine("---Dynamic coupling");
            object d = "Hello";
            PropertyInfo prop = d.GetType().GetProperty("Length");
            int length = (int)prop.GetValue(d, null);
            Console.WriteLine($"object d = \"Hello\";");
            Console.WriteLine($"PropertyInfo prop = d.GetType().GetProperty(\"Length\");");
            Console.WriteLine($"int length = (int)prop.GetValue(d, null); - {length}");
        }
    }
}
