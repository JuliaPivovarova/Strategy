﻿using System;
using Code.Abstractions;
using Code.UserControlSystem.UIModel.CommandCreators;
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
        private bool _commandIsPending;

        public void OnCommandButtonClicked(ICommandExecutor commandExecutor)
        {
            if (_commandIsPending)
            {
                ProcessOnCancel();
            }

            _commandIsPending = true;
            OnCommandAccepted?.Invoke(commandExecutor);
            _unitProducer.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _attacker.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _mover.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _holderPosition.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
            _patroller.ProcessCommandExecutor(commandExecutor,
                command => ExecuteCommandWrapper(commandExecutor, command));
        }

        private void ExecuteCommandWrapper(ICommandExecutor commandExecutor, object command)
        {
            commandExecutor.ExecuteCommand(command);
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
            
            OnCommandCancel?.Invoke();
        }
    }
}