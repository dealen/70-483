using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExceptionsBasics : IRun
    {
        public void Run()
        {
            CatchingAFormatException();
            CathcingMultipleExcepExceptionsTypes();
        }

        public void CatchingAFormatException()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) break;

                try
                {
                    var i = int.Parse(s);
                    break;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"{s} is not a valid number. Pleasy try again.");
                }
            }
        }

        private void CathcingMultipleExcepExceptionsTypes()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Argument provided was null.");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"{s} is not a valid number. Pleasy try again.");
            }
        }
    }
}
