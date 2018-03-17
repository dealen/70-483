using HelpersLibrary;
using System;
using System.Reflection;

namespace EnforcingEncapsulation
{
    public class ImplicitInterfaceImplementation : IRun
    {
        public void Run()
        {
            ImplicitInterface();
        }

        private void ImplicitInterface()
        {
            var myImpl = new MyImplementation();
            var myImpleCast = (IInterfaceA)new MyImplementation();
            //myImpl.MyMethod(); // nie ma dostepu do MyMethod
            myImpleCast.MyMethod();

            var moveableObj = new MoveableObject();
            ((ILeft)moveableObj).Move();
            ((IRight)moveableObj).Move();
        }
    }

    interface IInterfaceA
    {
        void MyMethod();
    }

    public class MyImplementation : IInterfaceA
    {
        /// <summary>
        /// Sposób na ukrywanie składowych 
        /// </summary>
        void IInterfaceA.MyMethod()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            Console.WriteLine("Methor from interface implementen explicitly.");
        }
    }

    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    class MoveableObject : ILeft, IRight
    {
        void ILeft.Move()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
        }

        void IRight.Move()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
        }
    }


}
