﻿using UnityEngine;

namespace Code.Abstractions
{
    public class PatrolCommandExecutor: CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patrol from {command.From} to {command.To}!");
        }
    }
}