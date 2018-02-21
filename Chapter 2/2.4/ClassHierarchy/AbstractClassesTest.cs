﻿using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class AbstractClassesTest : IRun
    {
        public void Run()
        {
            var a = new DerivedFromAbstract();
            a.Abstractmethod();
            a.MethodWithImplementation();
        }
    }

    abstract class AbstractBase
    {
        public virtual void MethodWithImplementation() { Console.WriteLine($"Method with implementation from abstract class"); }

        public abstract void Abstractmethod();
    }

    class DerivedFromAbstract : AbstractBase
    {
        public override void Abstractmethod()
        {
            Console.WriteLine($"-Abstractmethod--Method overriden from abstract class");
        }
    }
}
