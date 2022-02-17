using System;
using System.Collections.Generic;
using Code.Abstractions;
using Code.UserControlSystem.UIModel;
using Code.UserControlSystem.UIView;
using Code.Utils;
using UnityEngine;

namespace Code.UserControlSystem.UIPreseter
{
    public class CommandButtonPresenter: MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetContext _context;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += OnSelected;
            OnSelected(_selectable.CurrentValue);
            _view.OnClick += OnButtonClick;
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;
            
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutor = new List<ICommandExecutor>();
                commandExecutor.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutor);
            }
        }
        
        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }

            var patrol = commandExecutor as PatrolCommandExecutor;
            if (patrol != null)
            {
                patrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }
            
            var move = commandExecutor as MoveCommandExecutor;
            if (move != null)
            {
                move.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }
            
            var attack = commandExecutor as AttackCommandExecutor;
            if (attack != null)
            {
                attack.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                return;
            }

            var holdPosition = commandExecutor as HoldPositionCommandExecutor;
            if (holdPosition != null)
            {
                holdPosition.ExecuteSpecificCommand(_context.Inject(new HoldPositionCommand()));
                return;
            }

            throw new ApplicationException($"{nameof(CommandButtonPresenter)}.{nameof(OnButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }
    }
}