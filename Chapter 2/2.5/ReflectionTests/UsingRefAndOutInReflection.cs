using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class UsingRefAndOutInReflection : IRun
    {
        public void Run()
        {
            MakeByRefTypeSample();
        }

        private void MakeByRefTypeSample()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            int x;
            bool success = int.TryParse("123", out x);

            Console.WriteLine($"int x;");
            Console.WriteLine($"bool success = int.TryParse(\"123\", out x);");

            Console.WriteLine($"---Using reflection:");

            object[] args = { "123", 0  };
            Type[] argTypes = { typeof(string), typeof(int).MakeByRefType() };
            MethodInfo tryParse = typeof(int).GetMethod("TryParse", argTypes);
            bool isSuccessfull = (bool)tryParse.Invoke(null, args);
            Console.WriteLine("object[] args = { \"123\",0  };");
            Console.WriteLine("Type[] argTypes = { typeof(string),typeof(int).MakeByRefType() };");
            Console.WriteLine("MethodInfo tryParse = typeof(int).GetMethod(\"TryParse\", argTypes);");
            Console.WriteLine("bool isSuccessfull = (bool)tryParse.Invoke(null, args);");
            Console.WriteLine($"Result : {isSuccessfull}");
        }
    }
}
