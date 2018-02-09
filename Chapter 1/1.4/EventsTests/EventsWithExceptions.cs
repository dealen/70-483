using HelpersLibrary;
using System;

namespace EventsTests
{
    public class EventsWithExceptions : IRun
    {
        public void Run()
        {
            CreateAndRaise();
        }

        public void CreateAndRaise()
        {
            Ppp p = new Ppp();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e) => Console.WriteLine("when exception occurs it breaks all work.");//throw new Exception();
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called");

            p.Raise();
        }
    }

    public class Ppp
    {
        public event EventHandler OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, EventArgs.Empty);
        }
    }
}
