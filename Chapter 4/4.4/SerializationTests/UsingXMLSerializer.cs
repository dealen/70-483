using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationTests
{
    public class UsingXMLSerializer : IRun
    {
        public void Run()
        {
            UsingXMLSerialization();
            UsingXmlAttributesToConfigureSerialization();
        }

        private void UsingXMLSerialization()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            XmlSerializer serializer = new XmlSerializer(typeof(PersonSerializable));
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                PersonSerializable p = new PersonSerializable
                {
                    Firstname = "John",
                    Lastname = "Doe",
                    Age = 23
                };
                serializer.Serialize(sw, p);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader sr = new StringReader(xml))
            {
                PersonSerializable p = (PersonSerializable)serializer.Deserialize(sr);
                Console.WriteLine($"{p.Firstname} {p.Lastname} is {p.Age} years old");
            }
        }

        private Order CreateOrder()
        {
            var product1 = new Product { ID = 1, Description = "p1", Price = 9 };
            var product2 = new Product { ID = 2, Description = "p2", Price = 6 };

            var order = new VIPOrder
            {
                ID = 4,
                Description = "Order for special user",
                OrderLines = new List<OrderLine>
                {
                    new OrderLine{ ID = 5, Amount = 1, Product = product1 },
                    new OrderLine{ ID = 6, Amount = 10, Product = product2 }
                }
            };
            return order;
        }

        private void UsingXmlAttributesToConfigureSerialization()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });
            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                var order = CreateOrder();
                serializer.Serialize(sw, order);
                xml = sw.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader sr = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(sr);
            }
        }
    }

    [Serializable]
    public class PersonSerializable
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class Order
    {
        [XmlAttribute]
        public int ID { get; set; }

        [XmlIgnore]
        public bool IsDirty { get; set; }

        [XmlArray("Lines")]
        [XmlArrayItem("OrderLine")]
        public List<OrderLine> OrderLines { get; set; }
    }

    [Serializable]
    public class VIPOrder : Order
    {
        public string Description { get; set; }
    }

    [Serializable]
    public class OrderLine
    {
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public int Amount { get; set; }

        [XmlElement("OrderedProduct")]
        public Product Product { get; set; }
    }

    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
