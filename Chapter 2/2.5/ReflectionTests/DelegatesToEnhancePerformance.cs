using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class DelegatesToEnhancePerformance : IRun
    {
        public void Run()
        {
            UsingDelegatesToImprovePerformance();
        }

        delegate string StringToString(string s);

        private void UsingDelegatesToImprovePerformance()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            MethodInfo trimMethod = typeof(string).GetMethod("Trim", new Type[0]);
            var trim = (StringToString)Delegate.CreateDelegate(typeof(StringToString), trimMethod);
            var dtnow = DateTime.UtcNow;
            Console.WriteLine($"time: {dtnow.TimeOfDay.TotalSeconds} {dtnow.Ticks}");
            for (int i = 0; i < 1000000; i++)
            {
                trim("test");
            }
            var dtafter = DateTime.UtcNow;
            Console.WriteLine($"time: {dtafter.TimeOfDay.TotalSeconds} {dtafter.Ticks}");
            var resultA = dtafter.TimeOfDay.TotalSeconds - dtnow.TimeOfDay.TotalSeconds;
            Console.WriteLine($"Result = {resultA}");

            Console.WriteLine("Normal for with normal Trim();");
            dtnow = DateTime.UtcNow;
            Console.WriteLine($"time: {dtnow.TimeOfDay.TotalSeconds} {dtnow.Ticks}");
            for (int i = 0; i < 1000000; i++)
            {
                "trim".Trim();
            }
            dtafter = DateTime.UtcNow;
            Console.WriteLine($"time: {dtafter.TimeOfDay.TotalSeconds} {dtafter.Ticks}");
            var resultB = dtafter.TimeOfDay.TotalSeconds - dtnow.TimeOfDay.TotalSeconds;
            Console.WriteLine($"Result = {resultB}");

            Console.WriteLine($"Difference in times: {resultB - resultA}");
        }
    }
}
