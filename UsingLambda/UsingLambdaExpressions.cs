using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingLambda
{
    public class UsingLambdaExpressions : IRun
    {
        public delegate int Calculate(int x, int y);
        
        public void Run()
        {
            Basics();
            LambdaWithMultipleStatements();
            UsingFunc();
            UsingAction();
        }

        private void Basics()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));
        }

        private void LambdaWithMultipleStatements()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Calculate calc = (x, y) =>
            {
                Console.WriteLine("Adding numbers");
                return x + y;
            };

            int result = calc(3, 4);
            Console.WriteLine($"Result = {result}");
        }

        private void UsingFunc()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Func<int, int, string> calc = (x, y) =>
            {
                return $"Result of {x} plus {y} equals {(x + y)}.";
            };

            Console.WriteLine(calc(5, 8));
        }

        private void UsingAction()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Action<DateTime, int, string> greetings = (d, i, s) =>
            {
                Console.WriteLine($"Hello {s}, we have {i} day of year. Today is {d.ToShortDateString()}");
            };

            greetings(DateTime.Now, DateTime.Now.DayOfYear, "Kuba");
        }
    }
}
