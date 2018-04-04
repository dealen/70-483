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
    public class DirectoriesTests : IRun
    {
        public void Run()
        {
            CreatingNewDirectory();
            BuildingDirectoryTree();
            //MovingDirectories();
        }

        private void CreatingNewDirectory()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var directory = Directory.CreateDirectory(@"C:\Temp\ProgrammingInCSharp\Directory");
            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            directoryInfo.Create();
        }

        private void DeletingDirectory()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            if (Directory.Exists(@"C:\Temp\ProgrammingInCSharp\Directory"))
            {
                Directory.Delete(@"C:\Temp\ProgrammingInCSharp\Directory");
            }

            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete();
            }
        }

        private void BuildingDirectoryTree()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            DirectoryInfo di = new DirectoryInfo(@"C:\Program Files");
            ListDirectories(di, "*V*", 5, 0);
        }

        private void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
                return;

            string indent = new string('-', currentLevel);

            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);

                foreach (DirectoryInfo info in subDirectories)
                {
                    Console.WriteLine($"{indent} {info.Name}");
                    ListDirectories(info, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // yout don't have access to this folder
                Console.WriteLine($"{indent}Can't access: {directoryInfo.Name}");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // The folder is removed while iterating
                Console.WriteLine($"{indent}Can’t find: {directoryInfo.Name}");
                return;
            }
        }

        private void MovingDirectories()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var directory = Directory.CreateDirectory(@"C:\Temp\ProgrammingInCSharp\DirectoryToBeMoved");

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryToBeMoved");
            directoryInfo.MoveTo(@"C:\Temp\MovedDirectories\");
        }
    }
}
