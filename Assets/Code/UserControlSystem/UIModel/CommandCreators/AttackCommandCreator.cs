using System;
using Code.Abstractions;
using Code.Utils;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class AttackCommandCreator: CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetContext _context;
        private Action<IAttackCommand> _creationCallback;
        
        [Inject]
        private void Init(AttackableValue attackables)
        {
            attackables.OnNewValue += OnNewValue;
        }

        private void OnNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackable)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }
        
        public override void ProcessCancel()
        {
            base.ProcessCancel();

            _creationCallback = null;
        }
    }
}