using System;
using Code.Abstractions;
using Code.Utils;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class ProduceUnitCommandCreator: CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetContext _context;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        }
    }
}
