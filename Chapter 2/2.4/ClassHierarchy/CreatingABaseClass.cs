using HelpersLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClassHierarchy
{
    interface IEntity
    {
        int Id { get; }
    }

    class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    public class SomeType : IEntity
    {
        public SomeType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
    }

    public class CreatingABaseClass : IRun
    {
        Repository<SomeType> repository;

        public void Run()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var elements = new List<SomeType>();

            for (int i = 0; i < 100; i++)
            {
                var item = new SomeType(i, i.ToString());
                elements.Add(item);
            }

            var repository = new Repository<SomeType>(elements);
            Console.WriteLine(repository.FindById(4));
        }
    }
}
