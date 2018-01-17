using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
