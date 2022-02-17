namespace Code.Abstractions
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(object command);
    }
}