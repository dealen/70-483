using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class InheritingFromABaseClass
    {

    }

    public class Order : IEntity
    {
        public int Id { get; }
        public decimal Amount { get; set; }
    }

    class OrderRepository : Repository<Order>
    {
        public IEnumerable<Order> Elements
        {
            get; set;
        }

        public OrderRepository(IEnumerable<Order> elements) : base(elements)
        {
            Elements = elements;
        }

        public IEnumerable<Order> FilterOrdersOnAmont(decimal amount)
        {
            List<Order> result = null;

            result = Elements.Where(x => x.Amount == amount).ToList();

            return result;
        }

        //public override bool Equals(object obj)
        //{
        //    var repository = obj as OrderRepository;
        //    return repository != null &&
        //           EqualityComparer<IEnumerable<Order>>.Default.Equals(Elements, repository.Elements);
        //}

        //public override int GetHashCode()
        //{
        //    return 1573927372 + EqualityComparer<IEnumerable<Order>>.Default.GetHashCode(Elements);
        //}
    }
}
