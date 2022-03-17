using UniRx;

namespace Code.Abstractions
{
    public interface IUnitProducer
    {
        IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
        void Cancel(int index);
    }
}