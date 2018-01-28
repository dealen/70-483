using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsTests
{
    public class CustomEventAccess : IRun
    {
        public void Run()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var c = new CurtomEvt();
            c.OnChange += C_OnChange;
            c.Raise();
            c.OnChange -= C_OnChange;
            c.Raise();
        }

        private void C_OnChange(object sender, MyArgs e)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine("subscription to event");
        }
    }

    public class CurtomEvt
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock(onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            onChange(this, new MyArgs(42));
        }
    }
}
