using System.Threading.Tasks;
using Code.Abstractions;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Core
{
    public class ProduceUnitCommandExecutor: CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitParent;
        [SerializeField] private int _maxUnitQueue = 6;

        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();
        private DiContainer _diContainer = new DiContainer();

        private void Update()
        {
            if (_queue.Count == 0)
                return;
            
            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            
            if (innerTask.TimeLeft <= 0)
            {
                RemoveTaskAtIndex(0);
                var instance = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, transform.position,
                    Quaternion.identity, _unitParent);
                var queue = instance.GetComponent<ICommandsQueue>();
                var mainBuilding = GetComponent<MainBuilding>();
                queue.EnqueueCommand(new MoveCommand(mainBuilding.CollectionPoint));
            }
        }

        private void RemoveTaskAtIndex(int index)
        {
            for (int i = 0; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }

            _queue.RemoveAt(_queue.Count - 1);
        }

        public async override Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitName, command.UnitPrefab));
        }
        
        public void Cancel(int index) => RemoveTaskAtIndex(index);
    }
}