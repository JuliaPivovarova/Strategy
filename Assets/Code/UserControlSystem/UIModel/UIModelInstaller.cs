using System;
using Code.Abstractions;
using Code.Core;
using Code.UserControlSystem.UIModel.CommandCreators;
using Code.Utils;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIModel
{
    public class UIModelInstaller: MonoInstaller
    {
        [SerializeField] private AssetContext _legacyContext;
        [SerializeField] private Vector3Value _vector3Value;
        [SerializeField] private AttackableValue _attackableValue;
        [SerializeField] private SelectableValue _selectableValue;

        public override void InstallBindings()
        {
            Container.Bind<AssetContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_vector3Value);
            Container.Bind<AttackableValue>().FromInstance(_attackableValue);
            Container.Bind<SelectableValue>().FromInstance(_selectableValue);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IHoldPositionCommand>>().To<HoldPositionCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetCollectionPointCommand>>().To<SetCollectionPointCommandCreator>()
                .AsTransient();

            Container.Bind<float>().WithId("Chomper").FromInstance(5f);
            Container.Bind<string>().WithId("Chomper").FromInstance("Chomper");

            Container.Bind<CommandButtonsModel>().AsTransient();
            Container.Bind<BottomCenterModel>().AsTransient();
        }
    }
}