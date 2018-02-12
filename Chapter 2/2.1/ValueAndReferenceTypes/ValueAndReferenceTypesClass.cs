using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    public class ValueAndReferenceTypesClass : IRun
    {
        /// <summary>
        /// An example of
        /// a reference type is a uniform resource locator(URL). If you read something interesting on the
        /// web, you can send the URL to a friend and point to the correct location where the information is stored.
        /// A value type is different.If you read an interesting article in a magazine and
        /// you want to give it to your friend, you need to make a copy of the article and give it directly
        /// </summary>

        /*
         * Kiedy typ wartościowy?
         * - kiedy obiekt jest mały
         * - kiedy nie będzie podlegał zmianom
         * - kiedy jest wiele obiektów 
         * */

        public void Run()
        {
            TestReferenceTypes();
            TestValueTypes();
        }

        private void TestValueTypes()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var first = new TestValueTypes();
        }

        private void TestReferenceTypes()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var first = new TestReferenceTypes();
        }
    }
}
