using System;
using System.Reflection;

namespace HelpersLibrary
{
    public static class StaticValues
    {
        public static string MethodHeader => "---Current Method:";

        public static void WriteMethodName(MethodBase m)
        {
            Console.WriteLine($"{StaticValues.MethodHeader} {m.Name}");
        }
    }
}
