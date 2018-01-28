using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsTests
{
    public class EventsWithExceptionhandling : IRun
    {
        public void Run()
        {
            CreateAndRaise();
        }

        public void CreateAndRaise()
        {
            EventExceptionHandler e = new EventExceptionHandler();
            e.OnChange += (sender, evt) => Console.WriteLine("Subscriber 1 called");
            e.OnChange += (sender, evt) => throw new Exception();
            e.OnChange += (sender, evt) => Console.WriteLine("Subscriber 3 called");

            try
            {
                e.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Number of called exceptions: {ex.InnerExceptions.Count}");
            }
        }
    }

    public class EventExceptionHandler
    {
        public event EventHandler OnChange = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }
    }
}
