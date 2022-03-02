using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class Unit : MonoBehaviour, ISelectable, IAttackable
    {
        [SerializeField] private float _maxHealth = 150f;
        [SerializeField] private Sprite _icon;

        private float _health = 150f;
        private Transform _stayPoint;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform StayPoint => _stayPoint;
        public Sprite Icon => _icon;

        private void Start()
        {
            _stayPoint = GetComponent<Transform>();
        }
    }
}
