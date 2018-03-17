namespace ClassHierarchy
{
    public class ReadOnlyInterfaceSetGetClass : IReadOnlyInterface
    {
        public int Value { get; set; }
    }

    interface IReadOnlyInterface
    {
        int Value { get; }
    }

}
