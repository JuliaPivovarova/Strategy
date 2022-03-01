using Code.Abstractions;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class HoldPositionCommandCreator: CancellableCommandCreatorBase<IHoldPositionCommand, Vector3>
    {
        protected override IHoldPositionCommand CreateCommand(Vector3 argument) => new HoldPositionCommand(argument);
    }
}