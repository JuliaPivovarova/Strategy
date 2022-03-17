using Code.Abstractions;
using Code.Core;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class PatrolCommandCreator: CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) =>
            new PatrolCommand(_selectable.CurrentValue.Value.StayPoint.position, argument);
    }
}