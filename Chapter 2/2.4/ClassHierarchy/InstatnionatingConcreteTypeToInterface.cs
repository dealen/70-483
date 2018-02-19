using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class InstatnionatingConcreteTypeToInterface : IRun
    {
        public void Run()
        {
            IAnimal dog = new Dog();
            dog.Move();
            ((Dog)dog).Bark(); // inaczej niedostępne
            // kiedy obiekt jest instancjonowany do interfejsu to może wywoływać jedynie jego metody

            var cat = new Cat();
            MoveAnimal(cat); // działa, bo Cat implementuje interfejs IAnimal
        }

        private void MoveAnimal(IAnimal animal)
        {
            animal.Move();
        }
    }

    public class Cat : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Moving");
        }
    }

    public class Dog : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Moving");
        }

        public void Bark()
        {
            Console.WriteLine("Hau hau");
        }
    }

    interface IAnimal
    {
        void Move();
    }
}
