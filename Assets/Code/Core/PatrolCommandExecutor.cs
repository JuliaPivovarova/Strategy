using System.Threading.Tasks;
using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class PatrolCommandExecutor: CommandExecutorBase<IPatrolCommand>
    {
        public async override Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patrol from {command.From} to {command.To}!");
        }
    }
}