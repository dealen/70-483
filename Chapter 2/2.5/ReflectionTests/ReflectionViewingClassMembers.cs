using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTests
{
    public class ReflectionViewingClassMembers : IRun
    {
        public void Run()
        {
            GettingClassMembersInfo();
            UsingGetMethod();
            GettingPropertyIng();
        }

        private void GettingClassMembersInfo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            MemberInfo[] members = typeof(Walnut).GetMembers();
            Console.WriteLine($"Members of class {typeof(Walnut).FullName}");
            foreach (MemberInfo member in members)
            {
                Console.WriteLine(" ");
                Console.WriteLine(member);
                Console.WriteLine(member.MemberType);
                Console.WriteLine(member.ReflectedType);
                Console.WriteLine(member.DeclaringType);
            }

            Console.WriteLine($"-- Using TypeInfo");
            IEnumerable<MemberInfo> membersTI = typeof(Walnut).GetTypeInfo().DeclaredMembers;
            foreach (MemberInfo member in membersTI)
            {
                Console.WriteLine(" ");
                Console.WriteLine(member);
                Console.WriteLine(member.MemberType);
                Console.WriteLine(member.ReflectedType);
                Console.WriteLine(member.DeclaringType);
            }
            
            Console.WriteLine($"member.ReflectedType zwraca podtyp");
            Console.WriteLine($"member.DeclaringType zwraca typ bazowy");
        }

        private void UsingGetMethod()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            MethodInfo m = typeof(Walnut).GetMethod("Crack");
            Console.WriteLine($"{m}");
            Console.WriteLine($"{m.ReturnType}");

            MemberInfo mi = typeof(Walnut).GetMember("Crack")[0];

            Console.WriteLine($"MethodInfo(Crack) == MemberInfo(Crack) ? {mi == m}");
        }

        private void GettingPropertyIng()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            PropertyInfo pi = typeof(Walnut).GetProperty("MyProperty");
            MethodInfo getter = pi.GetGetMethod();
            MethodInfo setter = pi.GetSetMethod();
            MethodInfo[] both = pi.GetAccessors();
            Console.WriteLine($"pi.GetGetMethod() - {getter}");
            Console.WriteLine($"pi.GetSetMethod() - {setter}");
            Console.WriteLine("pi.GetAccessors(): ");
            foreach (MethodInfo item in both)
                Console.WriteLine($"- {item}");
            
        }
    }

    public class Walnut
    {
        private bool cracked;
        private int _myProperty;

        public void Crack() { cracked = true; }
        
        public int MyProperty {
            get { return _myProperty; }
            set { _myProperty = value; }
        }

        public override string ToString()
        {
            return cracked ? "Cracked" : "Not cracked";
        }
    }
}
