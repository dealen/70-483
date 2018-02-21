using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ThrowingExceptions : IRun
    {
        public void Run()
        {
            ThrownigAArgumentNullException();
        }

        private void ThrownigAArgumentNullException()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Console.WriteLine("Provide path to file:");
            var text = OpenAndParse(Console.ReadLine());

        }

        private string OpenAndParse(string filename)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException("filename", "Filename is required");
            }

            return File.ReadAllText(filename);
        }
    }
}
