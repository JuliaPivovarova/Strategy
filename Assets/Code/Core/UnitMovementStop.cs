using System;
using Code.Abstractions;
using Code.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Core
{
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
        {
            private readonly UnitMovementStop _unitMovementStop;

            public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += OnStop;
            }

            private void OnStop()
            {
                _unitMovementStop.OnStop -= OnStop;
                OnFinish(new AsyncExtensions.Void());
            }
        }

        public event Action OnStop;
        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);

        [SerializeField] private NavMeshAgent _agent;

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }
    }
}