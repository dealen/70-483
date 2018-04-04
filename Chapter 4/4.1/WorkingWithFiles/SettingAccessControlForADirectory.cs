using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFiles
{
    public class SettingAccessControlForADirectory : IRun
    {
        public void Run()
        {

        }

        private void SettingAccessControlForADirectoryTest()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            DirectoryInfo directoryInfo = new DirectoryInfo("TestDirectory");
            directoryInfo.Create();
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
