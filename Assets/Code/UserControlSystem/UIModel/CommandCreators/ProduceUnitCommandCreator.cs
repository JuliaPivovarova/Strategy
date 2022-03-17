using System;
using Code.Abstractions;
using Code.Core;
using Code.Utils;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class ProduceUnitCommandCreator: CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetContext _context;
        [Inject] private DiContainer _diContainer;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            var produceUnitCommand = _context.Inject(new ProduceUnitCommandHeir());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }
    }
}
