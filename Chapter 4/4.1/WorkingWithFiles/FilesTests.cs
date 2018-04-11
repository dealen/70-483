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
    public class FilesTests : IRun
    {
        public void Run()
        {
            ListFilesInDirectory(@"C:\Users\PLK050939.AD\Desktop");
        }

        private void ListFilesInDirectory(string directory)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Console.WriteLine(" Directory.GetFiles(directory)");
            foreach (string file in Directory.GetFiles(directory))
            {
                Console.WriteLine(file);
            }

            Console.WriteLine(" DirectoryInfo directoryInfo = new DirectoryInfo(directory)");
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine(fileInfo.FullName);
            }
        }

        /*
        string path = @”c:\temp\test.txt”;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
            fileInfo.Delete();
        }
        

        string path = @”c:\temp\test.txt”;
        string destPath = @”c:\temp\destTest.txt”;
        File.CreateText(path).Close();
        File.Move(path, destPath);
        FileInfo fileInfo = new FileInfo(path);
        fileInfo.MoveTo(destPath);


        string path = @”c:\temp\test.txt”;
        string destPath = @”c:\temp\destTest.txt”;
        File.CreateText(path).Close();
        File.Copy(path, destPath);
        FileInfo fileInfo = new FileInfo(path);
        fileInfo.CopyTo(destPath);

        */
    }
}
