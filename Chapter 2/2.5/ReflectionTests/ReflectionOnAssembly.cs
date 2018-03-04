using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTests
{
    class ReflectionOnAssembly : IRun
    {
        public void Run()
        {
            CreatingTypeWothActivatorClass();
        }

        private void CreatingTypeWothActivatorClass()
        {
            Assembly assembly = Assembly.Load("ReflectionTests");

            var plugins = from type in assembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
        }
    }
}
