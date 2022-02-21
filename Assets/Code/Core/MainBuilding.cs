using System;
using Code.Abstractions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
    
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
    
        private float _health = 1000;
        private Transform _stayPoint;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform StayPoint => _stayPoint;
        public Sprite Icon => _icon;

        private void Start()
        {
            _stayPoint = GetComponent<Transform>();
        }

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10)), Quaternion.identity, 
                _unitsParent);
        }
    }
}
