using System;
using Code.Abstractions;
using Code.Utils;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class HoldPositionCommandCreator: CommandCreatorBase<IHoldPositionCommand>
    {
        [Inject] private AssetContext _context;
        [Inject] private SelectableValue _selectable;

        protected override void ClassSpecificCommandCreation(Action<IHoldPositionCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new HoldPositionCommand(_selectable.CurrentValue.StayPoint.position)));
        }
    }
}