using HelpersLibrary;
using System;
using System.Reflection;

namespace EventsTests
{
    public class CustomEventHandler : IRun
    {
        public void Run()
        {
            CreateAndRaise();
        }

        public void CreateAndRaise()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var p = new Pub();
            p.OnChange += P_OnChange;
            p.OnChange += (sender, evtArgs) => { Console.WriteLine($"Event raised as lambda exp: {evtArgs.Value}."); };
            p.Raise();
        }

        private void P_OnChange(object sender, MyArgs e)
        {
            Console.WriteLine($"Event raised as method: {e.Value}.");
        }
    }

    public class MyArgs : EventArgs
    {
        public MyArgs(int val)
        {
            Value = val;
        }

        public int Value { get; set; }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            OnChange(this, new MyArgs(42));
        }
    }
}
