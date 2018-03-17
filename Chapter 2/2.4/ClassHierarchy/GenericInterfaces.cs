using System;
using System.Collections.Generic;

namespace ClassHierarchy
{
    class GenericInterfaces : IRepository<int>
    {
        public IEnumerable<int> All()
        {
            throw new NotImplementedException();
        }

        public int FindById(int id)
        {
            throw new NotImplementedException();
        }
    }

    interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
    }
}
