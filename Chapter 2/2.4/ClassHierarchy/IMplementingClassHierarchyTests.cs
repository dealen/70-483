using HelpersLibrary;
using System;

namespace ClassHierarchy
{
    public class IMplementingClassHierarchyTests : IRun, IExample
    {
        public int this[string index] { get { return 42; } set { } }

        public int Value { get; set; }

        public event EventHandler CalculationPerformed;

        public event EventHandler ResultRetrieved;

        public string GetResult()
        {
            return "result";
        }

        public void Run()
        {

        }
    }

    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
    }

}
