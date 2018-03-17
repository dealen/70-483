using HelpersLibrary;
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Exceptions
{
    public class DispatcherThrowMethod : IRun
    {
        public void Run()
        {
            UsingExcDispatcherThrowMethod();
        }

        private void UsingExcDispatcherThrowMethod()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            ExceptionDispatchInfo possibleException = null;

            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
            {
                //This method can be used to throw an exception and preserve the original stack trace.
                possibleException.Throw();
            }
        }
    }
}
