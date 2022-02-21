using UnityEngine;

namespace Code.Abstractions
{
    public class HoldPositionCommandExecutor: CommandExecutorBase<IHoldPositionCommand>
    {
        public override void ExecuteSpecificCommand(IHoldPositionCommand command)
        {
            Debug.Log($"{name} is holding position {command.PositionToHold}!");
        }
    }
}