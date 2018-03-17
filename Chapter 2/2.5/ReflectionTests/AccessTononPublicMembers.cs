using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public class AccessTononPublicMembers : IRun
    {
        public void Run()
        {
            AccessToNonPublicMembersOfType();
            GetAllStaticAndPublicMembers();
            GetAllStaticAndNonPublicMembersOfTypeObject();
            GetAllStaticAndNonPublicMembersOfType_Walnut();
            GetAllStaticAndNonPublicMembersOfType_Walnut_WithDeclaredOnly();
            GetAllPublicMembersOf_Walnut();
            GetAllPublicMembersOf_Walnut_DeclaredOnly();
        }

        /// <summary>
        /// Zmiana zmiennej prywatnej w klasie
        /// </summary>
        private void AccessToNonPublicMembersOfType()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Type t = typeof(Walnut);
            Walnut w = new Walnut();
            w.Crack();
            FieldInfo f = t.GetField("cracked", BindingFlags.NonPublic | BindingFlags.Instance);
            f.SetValue(w, false);
            Console.WriteLine(w);
        }

        private void GetAllStaticAndPublicMembers()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags publicStatic = BindingFlags.Public | BindingFlags.Static;
            MemberInfo[] members = typeof(object).GetMembers(publicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }
        
        private void GetAllStaticAndNonPublicMembersOfTypeObject()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags nonPublicStatic = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            MemberInfo[] members = typeof(object).GetMembers(nonPublicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }

        private void GetAllPublicMembersOf_Walnut()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags publicStatic = BindingFlags.Public | BindingFlags.Instance;
            MemberInfo[] members = typeof(Walnut).GetMembers(publicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }

        private void GetAllPublicMembersOf_Walnut_DeclaredOnly()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags publicStatic = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            MemberInfo[] members = typeof(Walnut).GetMembers(publicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }

        private void GetAllStaticAndNonPublicMembersOfType_Walnut()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags nonPublicStatic = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            MemberInfo[] members = typeof(Walnut).GetMembers(nonPublicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }

        private void GetAllStaticAndNonPublicMembersOfType_Walnut_WithDeclaredOnly()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            BindingFlags nonPublicStatic = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            MemberInfo[] members = typeof(Walnut).GetMembers(nonPublicStatic);
            var length = members.Length;
            for (int i = 0; i < length; i++)
            {
                var member = members[i];
                Console.WriteLine($"Name: {member.Name} Module: {member.Module}");
            }
        }
    }
}
