using Code.Abstractions;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class MoveCommandCreator: CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveCommand(argument);
    }
}