using Code.Abstractions;
using Code.Core;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class SetCollectionPointCommandCreator: CancellableCommandCreatorBase<ISetCollectionPointCommand, Vector3>
    {
        protected override ISetCollectionPointCommand CreateCommand(Vector3 argument) =>
            new SetCollectionPointCommand(argument);
    }
}