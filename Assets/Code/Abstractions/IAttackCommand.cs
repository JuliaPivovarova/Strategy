namespace Code.Abstractions
{
    public interface IAttackCommand: ICommand
    {
        IAttackable Target { get; }
    }
}