using UnityEngine;

namespace Code.Abstractions
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attack!");
        }
    }
}