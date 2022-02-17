using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class Unit : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 150f;
        [SerializeField] private Sprite _icon;

        private float _health = 150f;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
    }
}
