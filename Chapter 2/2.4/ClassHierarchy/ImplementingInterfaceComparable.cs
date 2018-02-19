using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class ImplementingInterfaceComparable : IRun
    {
        public void Run()
        {
            orders.Sort();
        }
        
        List<Order2> orders = new List<Order2>
        {
            new Order2 { CreatedAt = new DateTime(2018, 2, 1) },
            new Order2 { CreatedAt = new DateTime(2018, 2, 2) },
            new Order2 { CreatedAt = new DateTime(2018, 2, 3) },
            new Order2 { CreatedAt = new DateTime(2018, 2, 4) },
            new Order2 { CreatedAt = new DateTime(2018, 2, 5) },
        };

    }

    class Order2 : IComparable
    {
        public DateTime CreatedAt { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Order2 o = obj as Order2;

            if (o == null)
            {
                throw new ArgumentException("Object is not an Order2");
            }

            return this.CreatedAt.CompareTo(o.CreatedAt);
        }
    }
}
