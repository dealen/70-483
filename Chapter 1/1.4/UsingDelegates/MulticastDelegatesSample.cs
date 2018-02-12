using HelpersLibrary;
using System.Reflection;

namespace UsingDelegates
{
    public class MulticastDelegatesSample : IRun
    {
        public void Run()
        {
            Multicast();
        }

        public void MethodOne()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
        }

        public void MethodTwo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
        }

        public delegate void Del();

        public void Multicast()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Del d = MethodOne;
            d += MethodTwo;
            d();
        }
    }
}
