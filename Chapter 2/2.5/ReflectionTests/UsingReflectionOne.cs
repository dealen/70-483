using HelpersLibrary;

namespace ReflectionTests
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(MyApplication myApplication);
    }

    class UsingReflectionOne : IRun
    {
        public void Run()
        {

        }
    }

    class MyPlugin : IPlugin
    {
        public string Name { get { return "MyPlugin"; } }

        public string Description { get { return "My Sample Plugin"; } }

        public bool Load(MyApplication myApplication)
        {
            return true;
        }
    }

    public class MyApplication
    {
    }
}
