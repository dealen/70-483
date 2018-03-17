using HelpersLibrary;
using System;
using System.Reflection;

namespace ReflectionTests
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication myApplication);
    }

    public class InspectingAssemblyWithCustomPluginInterface : IRun
    {
        public void Run()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var myApp = new MyApplication();
            MyPlugin m = new MyPlugin();
            Console.WriteLine(m.Load(myApp));            
            Console.WriteLine(m.Description);
            Console.WriteLine(m.Name);
        }
    }

    class MyPlugin : IPlugin
    {
        public string Name { get { return "MyPlugin"; } }

        public string Description { get { return "My Sample Plugin"; } }

        public bool Load(MyApplication myApplication)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            return true;
        }
    }

    public class MyApplication
    {
    }
}
