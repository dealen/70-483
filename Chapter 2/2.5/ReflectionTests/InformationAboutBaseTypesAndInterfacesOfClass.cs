using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class InformationAboutBaseTypesAndInterfacesOfClass : IRun
    {
        public void Run()
        {
            GetBaseClassName();
            GetInterfacesName();
        }

        private void GetBaseClassName()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine($"System.String base type - {(typeof(System.String)).Name}");
        }

        private void GetInterfacesName()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine($"Interfeces implemented by class Guid:");
            foreach (Type iType in typeof(Guid).GetInterfaces())
            {
                Console.WriteLine($"{iType.Name}");
            }
        }
    }
}
