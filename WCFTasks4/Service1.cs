using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFTasks4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyFirstService : IMyFirstService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public IEnumerable<string> GetNames()
        {
            IEnumerable<string> list = new List<string>()
            {
                "Jeden", "Dwa", "Trzy", "Cztery", "Pięć", "Sześć"
            };
            return list;
        }

        //public async Task<IEnumerable<string>> GetNamesAsync()
        //{
        //    IEnumerable<string> list = new List<string>()
        //    {
        //        "Jeden", "Dwa", "Trzy", "Cztery", "Pięć", "Sześć"
        //    };
        //    return await Task<IEnumerable<string>>;
        //}

        //public Task<IEnumerable<string>> GetNamesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<int> GetNumbers()
        {
            return Enumerable.Range(1, 100);
        }

        //public Task<IEnumerable<int>> GetNumbersAsync()
        //{
        //    throw new NotImplementedException();
        //}
        
    }
}
