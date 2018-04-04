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
    public class EncodingAndDecoding : IRun
    {
        public void Run()
        {
            UsingFileCreateTextWithStreamWriter();
            OpeningFileStreamAndDecodeBytesToString();
        }

        private void UsingFileCreateTextWithStreamWriter()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string path = @"c:\temp\test1.dat";

            using (StreamWriter sw = File.CreateText(path))
            {
                string myVal = "my value";
                sw.Write(myVal);
            }
        }

        private void OpeningFileStreamAndDecodeBytesToString()
        {
            string path = @"c:\temp\test1.dat";
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] data = new byte[fs.Length];
                for (int i = 0; i < fs.Length; i++)
                {
                    data[i] = (byte)fs.ReadByte();
                }

                Console.WriteLine($"{Encoding.UTF8.GetString(data)}");
            }
        }
    }
}
