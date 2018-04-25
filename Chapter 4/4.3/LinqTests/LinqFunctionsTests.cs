using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqTests
{
    public class LinqFunctionsTests : IRun
    {
        int[] data1 = { 1, 3, 5 };
        int[] data2 = { 2, 5, 6 };

        public void Run()
        {
            MultipleFromStatements();
            UsingLinqOnCustomClass();
            UsingGroupingAndProjection();
            UsingJoin();
        }

        private void MultipleFromStatements()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var result = from d1 in data1
                         from d2 in data2
                         select d1 * d2;

            Console.WriteLine(string.Join(", ", result));
        }

        private void UsingLinqOnCustomClass()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var orders = PrepareData();

            var averangeNumberOfOrderLines = orders.Average(o => o.OrderLines.Count);
            Console.WriteLine($"Średnia liczba zamówień - {averangeNumberOfOrderLines}");
        }

        private void UsingGroupingAndProjection()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var orders = PrepareData();

            var result = from o in orders
                         from l in o.OrderLines
                         group l by l.Product into p
                         select new
                         {
                             Product = p.Key,
                             Amount = p.Sum(x => x.Amount)
                         };

            var resultType = result.GetType();

            Console.WriteLine($"Custom objects of type {resultType}");
            foreach (var item in result)
            {                
                Console.WriteLine($"{item.Product} - {item.Amount}");
            }
        }

        private void UsingJoin()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var products = PrepareProducts();
            string[] popularProductNames = { "Chleb", "Koszula" };
            var popularProd = from p in products
                              join n in popularProductNames on p.Description equals n
                              select p;
            Console.WriteLine("Popularne produkty");
            foreach (var item in popularProd)
            {
                Console.WriteLine($"{item.Description} {item.Price}");
            }
        }

        
        private List<ProductLinq> PrepareProducts()
        {
            List<ProductLinq> products = new List<ProductLinq>
            {
                new ProductLinq() { Description = "Mydło", Price = 10  },
                new ProductLinq() { Description = "Koszula", Price = 50  },
                new ProductLinq() { Description = "Chleb", Price = 30  },
                new ProductLinq() { Description = "Rower", Price = 139  }
            };

            return products;
        }

        private List<OrderLinq> PrepareData()
        {
            var products = PrepareProducts();

            var orderLine1 = new OrderLineLinq() { Amount = 2, Product = products[0] };
            var orderLine2 = new OrderLineLinq() { Amount = 3, Product = products[1] };
            var orderLine3 = new OrderLineLinq() { Amount = 5, Product = products[2] };
            var orderLine4 = new OrderLineLinq() { Amount = 1, Product = products[3] };

            var order1 = new OrderLinq()
            {
                OrderLines = new List<OrderLineLinq>() { orderLine3, orderLine4 }
            };

            var order2 = new OrderLinq()
            {
                OrderLines = new List<OrderLineLinq>() { orderLine3, orderLine4 }
            };
            var order3 = new OrderLinq()
            {
                OrderLines = new List<OrderLineLinq>() { orderLine4 }
            };
            var order4 = new OrderLinq()
            {
                OrderLines = new List<OrderLineLinq>() { orderLine1, orderLine4, orderLine2 }
            };

            return new List<OrderLinq>() { order1, order2, order3, order4 };
        }
    }


    public class ProductLinq
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderLineLinq
    {
        public int Amount { get; set; }
        public ProductLinq Product { get; set; }
    }

    public class OrderLinq
    {
        public List<OrderLineLinq> OrderLines { get; set; }
    }
}
