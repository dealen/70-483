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
    public class DrivesTest : IRun
    {
        public void Run()
        {
            GetDriveInfo();
        }

        private void GetDriveInfo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (DriveInfo item in drivesInfo)
            {
                Console.WriteLine($"Drive {item.Name}");
                Console.WriteLine($" File type: {item.DriveType}");

                if (item.IsReady)
                {
                    Console.WriteLine($" Volume label: {item.VolumeLabel}, ");
                    Console.WriteLine($" File system: {item.DriveFormat}");
                    Console.WriteLine($"Available space to current user:{item.AvailableFreeSpace, 15} bytes");
                    Console.WriteLine($"Total available space: {item.TotalFreeSpace, 15} bytes");
                    Console.WriteLine($"Total size of drive: {item.TotalSize, 15} bytes");
                }
            }
        }
    }
}
