using System.Threading;
using Code.Abstractions;

namespace Code.Core
{
    public class HoldPositionCommandExecutor: CommandExecutorBase<IHoldPositionCommand>
    {
        public CancellationTokenSource CtSource { get; set; }
        public override void ExecuteSpecificCommand(IHoldPositionCommand command)
        {
            CtSource?.Cancel();
        }
    }
}