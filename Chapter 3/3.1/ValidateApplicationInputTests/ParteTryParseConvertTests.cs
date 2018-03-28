using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidateApplicationInputTests
{
    public class ParteTryParseConvertTests : IRun
    {
        public void Run()
        {
            UsingParse();
            UsingTryParse("1");
            UsingTryParse("!");
            ParsingNumbersWithConfigurationOptions();
            UsingConvertClass("23");
            UsingConvertClass(null);
        }

        private void UsingParse()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string value = "true";
            Console.WriteLine($"Parsing string with value 'true' to bool");
            bool b = bool.Parse(value);
            Console.WriteLine($"Result = {b}");
        }

        private void UsingTryParse(string v)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            string value = v;
            int result;
            bool success = int.TryParse(value, out result);
            if (success)
            {
                Console.WriteLine($"Result of TryParse on string with value - '{value}' is: {result}");
            }
            else
            {
                Console.WriteLine($"Parsing wasn't successful with value '{value}'");
            }
        }

        private void ParsingNumbersWithConfigurationOptions()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            CultureInfo polish = new CultureInfo("Pl");
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");

            string value = "€19,95";
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english));
            Console.WriteLine(d.ToString(polish));
        }

        private void UsingConvertClass(string value)
        {
            Console.WriteLine($"Value to be converted: {value}");
            int i = Convert.ToInt32(value);
            Console.WriteLine(i);
        }
    }
}
