using System.Runtime.CompilerServices;

namespace Code.Abstractions
{
    public interface IAwaiter<TAwaited>: INotifyCompletion
    {
        bool IsCompleted { get; }
        TAwaited GetResult();
    }
}