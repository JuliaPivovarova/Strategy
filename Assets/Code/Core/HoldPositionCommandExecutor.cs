using System.Threading;
using System.Threading.Tasks;
using Code.Abstractions;

namespace Code.Core
{
    public class HoldPositionCommandExecutor: CommandExecutorBase<IHoldPositionCommand>
    {
        public CancellationTokenSource CtSource { get; set; }
        public async override Task ExecuteSpecificCommand(IHoldPositionCommand command)
        {
            CtSource?.Cancel();
        }
    }
}