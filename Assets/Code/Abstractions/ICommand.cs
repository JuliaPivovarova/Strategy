namespace Code.Abstractions
{
    public interface ICommand
    {
        string Name { get; }
        void DoCommand();
    }
}