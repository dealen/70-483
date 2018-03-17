using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionTests
{
    public class ViewingGenericClassesWithReflection : IRun
    {
        public void Run()
        {
            WorkingOnIEnumerableMethod_Where();
        }

        private void WorkingOnIEnumerableMethod_Where()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var unboundMethod = from m in typeof(Enumerable).GetMethods()
                    where m.Name == "Where" && m.IsGenericMethod
                    let parameters = m.GetParameters()
                    where parameters.Length == 2
                    let genArg = m.GetGenericArguments().First()
                    let enumerableOfT = typeof(IEnumerable<>).MakeGenericType(genArg)
                    let funcOfBool = typeof(Func<,>).MakeGenericType(genArg, typeof(bool))
                    where parameters[0].ParameterType == enumerableOfT &&
                        parameters[1].ParameterType == funcOfBool
                    select m;
            Console.WriteLine(unboundMethod);
            Console.WriteLine("");
            Console.WriteLine(unboundMethod.Single());
            Console.WriteLine("");
            var closedMethod = unboundMethod.Single().MakeGenericMethod(typeof(int));
            Console.WriteLine(closedMethod);

            int[] source = { 3, 4, 5, 6, 7, 8 };
            Func<int, bool> predicate = n => n % 2 == 1;//nieparzyste
            var query = (IEnumerable<int>)closedMethod.Invoke(null, new object[] { source, predicate });
            foreach (int element in query)
            {
                Console.WriteLine($"{element} |");
            }
        }
    }
}
