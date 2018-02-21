using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExceptionInspecting : IRun
    {
        public void Run()
        {
            InspectingException();
        }

        private void InspectingException()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            try
            {
                int i = ReadAndParse();
                Console.WriteLine($"Parsed {i}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                Console.WriteLine($"HelpLink: {e.HelpLink}");
                Console.WriteLine($"InnerExceltion: {e.InnerException}");
                Console.WriteLine($"TargetSite: {e.TargetSite}");
                Console.WriteLine($"Source: {e.Source}");
            }
        }

        private int ReadAndParse()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }
    }
}
