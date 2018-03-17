using HelpersLibrary;
using System;

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
