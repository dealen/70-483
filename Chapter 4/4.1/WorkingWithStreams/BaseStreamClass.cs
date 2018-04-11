using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStreams
{
    public class BaseStreamClass : IRun
    {
        public void Run()
        {
            CreatingAndUsingAFileStream();
        }

        private void CreatingAndUsingAFileStream()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string path = @"c:\temp\test.dat";

            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "My value";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }
    }
}
