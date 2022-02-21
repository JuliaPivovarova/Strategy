using System;
using Code.Abstractions;
using Code.Utils;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public class PatrolCommandCreator: CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetContext _context;
        [Inject] private SelectableValue _selectable;
        
        private Action<IPatrolCommand> _creationCallback;
        
        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnNewValue += OnNewValue;
        }
        
        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(_selectable.CurrentValue.StayPoint.position, groundClick)));
            _creationCallback = null;
        }
        
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
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