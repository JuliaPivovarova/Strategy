using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class MainBuilding : MonoBehaviour, ISelectable, IAttackable
    {
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health = 1000;
        private Transform _stayPoint;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform StayPoint => _stayPoint;
        public Sprite Icon => _icon;
        public Vector3 CollectionPoint { get; set; }

        private void Start()
        {
            _stayPoint = GetComponent<Transform>();
        }
    }
}
