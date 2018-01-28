﻿using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegates
{
    public class CovarianceContrvarianceAndDelegates : IRun
    {
        public delegate TextWriter CovarianceDel();
        public StreamWriter MethodStream()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            return null;
        }
        public StreamWriter MethodString()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            return null;
        }

        public void Run()
        {
            CovarianceDelegateBasics();
        }

        private void CovarianceDelegateBasics()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }

        void DoSomething(TextWriter tw) { }
        public delegate void ContrvarianceDel(StreamWriter tw);

        private void ContrvarianceBasics()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            ContrvarianceDel del = DoSomething;
        }
    }
}
