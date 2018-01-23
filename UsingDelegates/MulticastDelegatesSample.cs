using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            Del d = MethodOne;
            d += MethodTwo;
            d();
        }
    }
}
