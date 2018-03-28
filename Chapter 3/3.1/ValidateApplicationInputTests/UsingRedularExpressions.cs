using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidateApplicationInputTests
{
    public class UsingRedularExpressions : IRun
    {
        public void Run()
        {
            ValidatingZIPWithRegex("1234AB");
            ValidatingZIPWithRegex("53-543");
            ValidatingZIPWithRegex("ASDC12");
        }

        private void ValidatingZIPWithRegex(string zipCode)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            Console.WriteLine($"Is zip code {zipCode} matching pattern? {match.Success}");
        }

        /// <summary>
        /// Validating without regex
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        private bool ValidateZipCode(string zipCode)
        {
            // Valid zipcodes: 1234AB | 1234 AB | 1001 AB
            if (zipCode.Length < 6) return false;
            string numberPart = zipCode.Substring(0, 4);
            int number;
            if (!int.TryParse(numberPart, out number)) return false;
            string characterPart = zipCode.Substring(4);
            if (numberPart.StartsWith("0")) return false;
            if (characterPart.Trim().Length < 2) return false;
            if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
                return false;
            return true;
        }
    }
}
