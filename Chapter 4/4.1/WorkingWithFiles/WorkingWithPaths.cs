using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFiles
{
    public class WorkingWithPaths : IRun
    {
        public void Run()
        {
            UsingPathCombine();
            UsingPathgetMethods();
        }

        private void UsingPathCombine()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string folder = @"C:\temp";
            string fileName = "test.dat";

            string fullPath = Path.Combine(folder, fileName);
            Console.WriteLine($"Combined path: {fullPath}");
        }

        private void UsingPathgetMethods()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string path = @"C:\Users\PLK050939.AD\Desktop\jjnj.txt";

            Console.WriteLine(Path.GetDirectoryName(path));//
            Console.WriteLine(Path.GetExtension(path));
            Console.WriteLine(Path.GetFileName(path));
            Console.WriteLine(Path.GetPathRoot(path));
        }
    }
}
