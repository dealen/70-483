using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class InvokingGenericMethod : IRun
    {
        public static T Echo<T>(T x) { return x; }

        public void Run()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            MethodInfo echo = typeof(InvokingGenericMethod).GetMethod("Echo");
            MethodInfo intEcho = echo.MakeGenericMethod(typeof(int)); // bez tej linijki wyrzuci błąd
            Console.WriteLine($"echo.IsGenericMethod ? {echo.IsGenericMethod}");
            Console.WriteLine($"intEcho.IsGenericMethod ? {intEcho.IsGenericMethod}");
            Console.WriteLine($"intEcho.IsGenericMethodDefinition ? {intEcho.IsGenericMethodDefinition}");
            Console.WriteLine($"intEcho.Invoke(null, new object[] [ 1, 2, 3 ]) ? {intEcho.Invoke(null, new object[] { 3 })}");
            //echo.Invoke(null, new object[] { 1, 2, 3 });
        }


    }
}
