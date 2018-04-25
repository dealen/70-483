using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqTests
{
    public class UsingLinqWithXML : IRun
    {
        private String xml = @"<?xml version =""1.0"" encoding=""utf-8"" ?>
                                <people>
                                <person firstname =""john"" lastname=""doe"">
                                <contactdetails>
                                <emailaddress>john @unknown.com</emailaddress>
                                </contactdetails>
                                </person>
                                <person firstname =""jane"" lastname=""doe"">
                                <contactdetails>
                                <emailaddress>jane @unknown.com</emailaddress>
                                <phonenumber>001122334455</phonenumber>
                                </contactdetails>
                                </person>
                                </people>";

        public void Run()
        {
            QueryingSomeXMLByUsingLinqToXML();
            UsingWhereAndOrderByWithLinqToXML();
            UpdatingXmlInProceruralWay();
        }

        private void QueryingSomeXMLByUsingLinqToXML()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> parsedNodes = from p in doc.Descendants("person")
                                              select (string)p.Attribute("firstname")
                                              + " " + (string)p.Attribute("lastname");

            Console.WriteLine("Wynik parsowania xml przy użuyciu Linq");
            foreach (string s in parsedNodes)
            {
                Console.WriteLine(s);
            }
        }

        private void UsingWhereAndOrderByWithLinqToXML()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> personNames = from p in doc.Descendants("person")
                                              where p.Descendants("phonenumber").Any()
                                              let name = (string)p.Attribute("firstname")
                                              + " " + (string)p.Attribute("lastname")
                                              orderby name
                                              select name;
            Console.WriteLine("Sorted items from xml");
            foreach (var item in personNames)
            {
                Console.WriteLine(item);
            }
        }

        private void CreatinXML()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            XElement root = new XElement("root", new List<XElement>
            {
                new XElement("Child1"),
                new XElement("Child2", new List<XElement> { new XElement("Child of a Child2")}),
                new XElement("Child3"),
            },
            new XAttribute("MyAttribute", 42));
            root.Save("test.xml");
        }

        private void UpdatingXmlInProceruralWay()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            XElement root = XElement.Parse(xml);

            foreach (XElement element in root.Descendants("person"))
            {
                string name = (string)element.Attribute("firstname") + (string)element.Attribute("lastname");
                element.Add(new XAttribute("IsMale", name.ToLower().Contains("john")));
                XElement contactDetails = element.Element("contactdetails");
                if (!contactDetails.Descendants("phonenumber").Any())
                {
                    contactDetails.Add(new XElement("phonenumber", "0092272728829"));
                }
            }

            IEnumerable<string> parsedNodes = from p in doc.Descendants("person")
                                              select (string)p.Attribute("firstname")
                                              + " " + (string)p.Attribute("lastname");

            foreach (var item in root.Descendants("person"))
            {
                Console.WriteLine($"");
            }
        }


    }
}
