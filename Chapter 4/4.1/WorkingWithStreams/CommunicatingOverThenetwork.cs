using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStreams
{
    public class CommunicatingOverThenetwork : IRun
    {
        public void Run()
        {
            ExecutingAWebRequest();
        }

        private void ExecutingAWebRequest()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            WebResponse response = request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string responseText = sr.ReadToEnd();

            Console.WriteLine(responseText);

            response.Close();
        }
    }
}
