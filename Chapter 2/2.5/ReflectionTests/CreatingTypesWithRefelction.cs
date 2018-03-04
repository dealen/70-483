using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTests
{
    public class CreatingTypesWithRefelction : IRun
    {
        public void Run()
        {
            CreatingTypeUsingActivate();
            CreatringTypeByUsingInvokeFromConstructorInfo();
            CreatringTypeByUsingInvokeFromConstructorInfoInWindowsStore();
        }

        /// <summary>
        /// Metoda CreateInstance przyjmuje typ jaki ma stworzyć oraz można podać parametry konstruktora 
        /// Jeśli nie zostanie znaleziony odpowiedni konstruktor to metoda rzuca MissingMethodExcepotion
        /// </summary>
        private void CreatingTypeUsingActivate()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            int i = (int)Activator.CreateInstance(typeof(int));
            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime), 2000, 1, 1);
            Console.WriteLine($"Type using (int)Activator.CreateInstance(typeof(int)); is {i.GetType().FullName}");
        }

        /// <summary>
        /// Mozna także 'wyszukiwać' danego konstruktora wśród zadeklarowanych w klasie jakiej instancję chce się stworzyć
        /// </summary>
        private void CreatringTypeByUsingInvokeFromConstructorInfo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            
            ConstructorInfo ci = typeof(StringBuilder).GetConstructor(new Type[] { typeof(int), typeof(int) });
            object foo = ci.Invoke(new object[] { 200, 300 });
            Console.WriteLine($"Should be StringBuilder and is - {foo.GetType().FullName}");
        }

        /// <summary>
        /// Przykład użycia ConstructorInfo dla aplikacji Windows Store
        /// </summary>
        private void CreatringTypeByUsingInvokeFromConstructorInfoInWindowsStore()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            ConstructorInfo info = typeof(StringBuilder).GetTypeInfo().DeclaredConstructors.FirstOrDefault(
                x => 
                    x.GetParameters().Length == 2 &&
                    x.GetParameters()[0].ParameterType == typeof(int) &&
                    x.GetParameters()[1].ParameterType == typeof(int)  
                );
            object foo = info.Invoke(new object[] { 522, 600 });
            Console.WriteLine($"Should be StringBuilder and is - {foo.GetType().FullName}");
        }
    }
}
