using HelpersLibrary;
using System;
using System.Reflection;

namespace Exceptions
{
    public class ExceptionWithFinally : IRun
    {
        public void Run()
        {
            ExceptionWithFinallyBlock();
            UsingEnvironmentalFailFast();
        }

        private void ExceptionWithFinallyBlock()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"You need to pass value.");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"'{s}' is not a number. Try again.");
            }
            finally
            {
                Console.WriteLine("Method completed");
            }
        }

        private void UsingEnvironmentalFailFast()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
                if (i == 42) Environment.FailFast("Special number entered");
            }
            finally
            {
                Console.WriteLine("Program completed");
            }
        }
    }
}
