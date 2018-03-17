using HelpersLibrary;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassHierarchy
{
    public class ImplementingIEnumerable : IRun
    {
        public void Run()
        {

        }

        private void ForeachLoopWithGetEnumerator()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 5, 7, 9 };
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }
        }
    }

    public class Person
    {
        public Person(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class People : IEnumerable<Person>
    {
        public People(Person[] persons)
        {
            this.people = persons;
        }

        Person[] people;

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < people.Length; i++)
            {
                yield return people[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
