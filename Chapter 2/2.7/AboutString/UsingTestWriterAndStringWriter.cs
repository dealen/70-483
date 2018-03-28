using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AboutString
{
    public class UsingTestWriterAndStringWriter : IRun
    {
        public void Run()
        {
            XmlWriterFromStringWriter();
            FormattingStrings();
        }

        private void XmlWriterFromStringWriter()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var stringWriter = new StringWriter();
            using (XmlWriter write = XmlWriter.Create(stringWriter))
            {
                write.WriteStartElement("book");
                write.WriteElementString("price", "19.95");
                write.WriteEndElement();
                write.Flush();
            }
            string xml = stringWriter.ToString();

            Console.WriteLine(xml);

            var stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = 0;
                if (!decimal.TryParse(reader.ReadInnerXml(), NumberStyles.Any, new CultureInfo("en-US"), out price))
                    throw new FormatException("decimal in xml was provided with wrong format");
                Console.WriteLine($"Decimal red from string xml: {price}");
            }
        }

        private void FormattingStrings()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            decimal price = 1234.56M;
            Console.WriteLine(@"{price.ToString(\""C"")}");
            Console.WriteLine($"{price.ToString("C")}");

            DateTime date = new DateTime(2018, 03, 28);
            Console.WriteLine(@"{date.ToString(\""d\"", new CultureInfo(\""en - US\""))}");
            Console.WriteLine($"{date.ToString("d", new CultureInfo("en-US"))}");
            Console.WriteLine(@"{date.ToString(\""D\"", new CultureInfo(\""en - US\""))}");
            Console.WriteLine($"{date.ToString("D", new CultureInfo("en-US"))}");
            Console.WriteLine(@"{date.ToString(\""M\"", new CultureInfo(\""en - US\""))}");
            Console.WriteLine($"{date.ToString("M", new CultureInfo("en-US"))}");
            Console.WriteLine(@"{date.ToString(\""d\"", new CultureInfo(\""pl-PL\""))}");
            Console.WriteLine($"{date.ToString("d", new CultureInfo("pl-PL"))}");
            Console.WriteLine(@"{date.ToString(\""D\"", new CultureInfo(\""pl-PL\""))}");
            Console.WriteLine($"{date.ToString("D", new CultureInfo("pl-PL"))}");
            Console.WriteLine(@"{date.ToString(\""M\"", new CultureInfo(\""pl-PL\""))}");
            Console.WriteLine($"{date.ToString("M", new CultureInfo("pl-PL"))}");
        }
    }
}
