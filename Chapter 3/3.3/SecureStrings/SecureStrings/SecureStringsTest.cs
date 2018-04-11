using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecureStrings
{
    public class SecureStringsTest : IRun
    {
        public void Run()
        {
            var password = BasicUsageOfSecureStringClass();
            GetingValueOutFromSecureString(password);
        }

        public SecureString BasicUsageOfSecureStringClass()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var password = new SecureString();
            using (SecureString ss = new SecureString())
            {
                Console.WriteLine("Please enter password");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key...");
                //ss.MakeReadOnly();
                password = ss.Copy();
            }
            return password;
        }

        public void GetingValueOutFromSecureString(SecureString password)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
