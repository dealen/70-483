using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class ReadOnlyInterfaceSetGetClass : IReadOnlyInterface
    {
        public int Value { get; set; }
    }

    interface IReadOnlyInterface
    {
        int Value { get; }
    }

}
