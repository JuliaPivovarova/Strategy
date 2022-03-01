using System.Threading;
using Code.Abstractions;
using Code.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Core
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private HoldPositionCommandExecutor _holdPositionCommandExecutor;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger(Walk);
            _holdPositionCommandExecutor.CtSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_holdPositionCommandExecutor.CtSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }

            _holdPositionCommandExecutor.CtSource = null;
            _animator.SetTrigger(Idle);
        }
    }
}