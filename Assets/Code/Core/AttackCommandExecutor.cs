using System.Threading.Tasks;
using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        public async override Task ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking {command.Target}!");
        }
    }
}