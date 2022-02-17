﻿using UnityEngine;

namespace Code.Abstractions
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log("Move!");
        }
    }
}