using HelpersLibrary;
using System;
using System.Linq;
using System.Reflection;

namespace ReflectionTests
{
    public class LoadingAssemblyInfo : IRun
    {
        public void Run()
        {
            //GetAssemblyInfo();
        }

        private void GetAssemblyInfo()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            Assembly pluginAssembly = Assembly.Load("ReflectionTests.dll"); //??
            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
        }
    }
}
