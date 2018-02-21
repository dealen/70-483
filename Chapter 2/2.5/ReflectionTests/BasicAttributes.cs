using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTests
{
    public class BasicAttributes : IRun
    {
        public void Run()
        {

        }


    }

    [Serializable]
    class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //[Conditional()]
        public void MethodUnderCondition()
        {

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class CompleteCustomAttribute : Attribute
    {
        public CompleteCustomAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
