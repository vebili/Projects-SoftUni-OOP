namespace PersonInfo
{
    public interface IPerson : IIdentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}