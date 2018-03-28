using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace ValidateApplicationInputTests
{
    public class ValidatingJSONandXML : IRun
    {
        public void Run()
        {
            IsJsonWitlLittleCriteria("[]");
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sample.json");
            CheckingJsonWithJSSerializer(json);
            
            ValidateXML();
        }

        private void IsJsonWitlLittleCriteria(string input)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine(input);
            input = input.Trim();
            var result = input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]");
            Console.WriteLine($"is json? {result}");
        }

        private void CheckingJsonWithJSSerializer(string json)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, object>>(json);
            foreach (var item in result.Keys)
            {
                Console.WriteLine($"Key {item}");
                Console.WriteLine($"Value {result[item]}");
            }
            Console.WriteLine(result);
        }

        private void ValidateXML()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "sample.xml");
            XmlDocument document = new XmlDocument();
            document.Schemas.Add("", AppDomain.CurrentDomain.BaseDirectory + "sample.xsd");
            document.Load(reader);

            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            document.Validate(eventHandler);
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine($"Error: {e.Message}");
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine($"Warning: {e.Message}");
                    break;
                default:
                    break;
            }
        }
    }
}
