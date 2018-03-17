using HelpersLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionTests
{
    public class CallingMembersOfGenericInterface : IRun
    {
        public void Run()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine(ToStringEx(new List<int> { 5, 6, 7 }));
            Console.WriteLine(ToStringEx("xyyzzz".GroupBy(c => c)));
        }

        private static string ToStringEx(object value)
        {
            if (value == null) return "<null>";
            StringBuilder sb = new StringBuilder();

            if (value is IList) //List <> nie można odwołać się, więc używamy IList
            {
                sb.Append($"Lista {((IList)value)} items");
            }

            //if (value is IGrouping<,>)// nie można odwołać się, więc trzeba użyć refleksji
            Type closingIGrouping = value.GetType().GetInterfaces()
                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IGrouping<,>)).FirstOrDefault();
            if (closingIGrouping != null)
            {
                PropertyInfo pi = closingIGrouping.GetProperty("Key");
                object key = pi.GetValue(value, null);
                sb.Append($"Grupowanie z kluczem {key}");
            }

            if (value is IEnumerable)
                foreach (object element in ((IEnumerable)value))
                {
                    sb.Append($"{ToStringEx(element)} ");
                }

            if (sb.Length == 0) sb.Append(value.ToString());
            return $"\r\r{sb.ToString()}";
        }
    }
}
