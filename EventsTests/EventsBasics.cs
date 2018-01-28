using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventsTests
{
    public class EventsBasics : IRun
    {
        public void Run()
        {
            CreateAndRaise();
            EventUsingEventKeyword();
        }

        private void CreateAndRaise()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Pup p = new Pup();
            p.OnChange += () => Console.WriteLine("Event raised to method 1");
            p.OnChange += () => Console.WriteLine("Event raised to method 2");
            p.Raise();
        }

        private void EventUsingEventKeyword()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Pup p = new Pup();
            p.OnChange2 += () => { Console.WriteLine($"Raising event using event keyword 1"); };
            p.OnChange2 += () => { Console.WriteLine($"Raising event using event keyword 1"); };
            p.Raise2();
        }
        
    }

    public class Pup
    {
        public event Action OnChange2 = delegate { };
        public Action OnChange { get; set; }

        public void Raise()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            if (OnChange != null)
            {
                OnChange();
            }
        }

        public void Raise2()
        {
            OnChange2();
        }
    }
}
