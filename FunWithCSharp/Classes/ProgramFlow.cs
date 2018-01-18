using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace FunWithCSharp.Classes
{
    public class ProgramFlow : IRun
    {
        public void Run()
        {
            UsingXOR();
            NullCoalescingOperator();
            ConditionalOperator();
            ForLoopWithMultipleVariables();
            SecondForLoopWithTwoVariables();
        }

        private void UsingXOR()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            bool a = true;
            bool b = false;

            Console.WriteLine(a ^ a);
            Console.WriteLine(a ^ b);
            Console.WriteLine(b ^ b);
        }

        private void NullCoalescingOperator()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            int? x = null;
            int? z = null;
            int y = x ?? z ?? -1;
            Console.WriteLine(y);
        }

        private void ConditionalOperator()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var rand = new Random();
            var input = rand.Next(0, 1000);

            var even = "even";
            var odd = "odd";

            var result = (input % 2 == 0) ? even : odd;

            Console.WriteLine($"Result is {result} ({input})");
        }

        private void ForLoopWithMultipleVariables()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            for (int i = 0, y = 0; (i < 1000) && (y !=1); i++)
            {
                if (i == 50)
                {
                    y = 1;
                    Console.WriteLine("y = 1");
                }
                if (i > 50)
                    Console.WriteLine("something went wrong...");
            }
        }

        private void SecondForLoopWithTwoVariables()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            int[] values = { 1, 2, 3, 4, 5, 7, 9, 12 };

            for (int x = 0, y = values.Length - 1; (x < values.Length) && (y >= 0); x++, y--)
            {
                Console.WriteLine(values[x]);
                Console.WriteLine(values[y]);
            }
        }
    }
}
