namespace Code.Abstractions
{
    public interface ICommandsQueue
    {
        void EnqueueCommand(object command);
        void Clear();
    }
}