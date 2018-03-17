using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ReflectionTests
{
    public class UsingTypeOfTests : IRun
    {
        public void Run()
        {
            UsingTypeofBasic();
            GetTypeNameFromStringWithName();
            NazwaKwalifikowanaPodzespolu();
            ArrayTypeFromElementType();
            NestedTypes();
        }

        private void UsingTypeofBasic()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Type t1 = DateTime.Now.GetType();
            t1.WriteToScreen();
            Type t2 = typeof(Dictionary<int, List<string>>);
            t2.WriteToScreen();
        }

        private void GetTypeNameFromStringWithName()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Type t = Assembly.GetExecutingAssembly().GetType("ReflectionTests.UsingTypeOfTests");
            t.WriteToScreen();
        }

        private void NazwaKwalifikowanaPodzespolu()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Type t = Type.GetType("System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            t.WriteToScreen();
        }

        private void ArrayTypeFromElementType()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Type t = typeof(Int32).MakeArrayType();
            t.WriteToScreen();

            Console.WriteLine($"Rozmiar wymiarów tablicy {t.Name} = {t.GetArrayRank()}");

            Type t2 = typeof(Int32[,,]);
            t2.WriteToScreen();
            Console.WriteLine($"Rozmiar wymiarów tablicy {t2.Name} = {t2.GetArrayRank()}");
        }

        /// <summary>
        /// Typy osadzone - wewnętrzne
        /// </summary>
        private void NestedTypes()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            foreach (Type t in typeof(System.Environment).GetNestedTypes())
            {
                Console.WriteLine($"{t.FullName}");
            }

            Console.WriteLine($"In Windows Store application:");
            foreach (TypeInfo info in typeof(System.Environment).GetTypeInfo().DeclaredNestedTypes)
            {
                Console.WriteLine(info.FullName);
                //
                Debug.WriteLine(info.FullName);
            }
        }
    }

    public static class ExtensionOfType
    {
        public static void WriteToScreen(this Type type)
        {
            Console.WriteLine($"Type {type.Name} - {type.ToString()}");
        }
    }
}
