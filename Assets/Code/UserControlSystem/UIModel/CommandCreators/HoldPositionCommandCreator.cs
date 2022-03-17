using Code.Abstractions;
using Code.Core;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class HoldPositionCommandCreator: CancellableCommandCreatorBase<IHoldPositionCommand, Vector3>
    {
        protected override IHoldPositionCommand CreateCommand(Vector3 argument) => new HoldPositionCommand();
    }
}