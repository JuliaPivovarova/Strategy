using System;
using Code.Abstractions;
using Code.Core;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIModel
{
    public class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
        [Inject] private CommandCreatorBase<IMoveCommand> _mover;
        [Inject] private CommandCreatorBase<IHoldPositionCommand> _holderPosition;
        [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;
        [Inject] private CommandCreatorBase<ISetCollectionPointCommand> _setterCollectionPoint;
        private bool _commandIsPending;

        public void OnCommandButtonClicked(ICommandExecutor commandExecutor, ICommandsQueue queue)
        {
            if (_commandIsPending)
            {
                ProcessOnCancel();
            }

            _commandIsPending = true;
            OnCommandAccepted?.Invoke(commandExecutor);
            
            _unitProducer.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
            _attacker.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
            _mover.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
            _holderPosition.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
            _patroller.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
            _setterCollectionPoint.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(command, queue));
        }

        private void ExecuteCommandWrapper(object command, ICommandsQueue queue)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                queue.Clear();
            }
            queue.EnqueueCommand(command);
            _commandIsPending = false;
            OnCommandSent?.Invoke();
        }

        public void OnSelectionChanged()
        {
            _commandIsPending = false;
            ProcessOnCancel();
        }

        private void ProcessOnCancel()
        {
            _unitProducer.ProcessCancel();
            _attacker.ProcessCancel();
            _mover.ProcessCancel();
            _holderPosition.ProcessCancel();
            _patroller.ProcessCancel();
            _setterCollectionPoint.ProcessCancel();
            
            OnCommandCancel?.Invoke();
        }
    }
}