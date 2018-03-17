using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTests
{
    public class GettingMembersOfGenericClasses : IRun
    {
        public void Run()
        {
            GetGenericClassMembersInfo();
        }

        private void GetGenericClassMembersInfo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            PropertyInfo unbound = typeof(IEnumerator<>).GetProperty("Current");
            PropertyInfo closed = typeof(IEnumerator<int>).GetProperty("Current");

            Console.WriteLine($"typeof(IEnumerable<>).GetProperty(\"Current\") - {unbound}");
            Console.WriteLine($"typeof(IEnumerable<int>).GetProperty(\"Current\") - {closed}");

            Console.WriteLine($"unbound.PropertyType.IsGenericParameter - {unbound.PropertyType.IsGenericParameter}"); // true
            Console.WriteLine($"closed.PropertyType.IsGenericParameter - {closed.PropertyType.IsGenericParameter}"); // false
        }
    }
}
