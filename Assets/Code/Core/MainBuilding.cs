using Code.Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Code.Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
    
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Slider _waitForCreationSlider;

        private float _health = 1000;
        private Transform _stayPoint;
        private bool _creationStarted = false;

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
            if (!_creationStarted)
            {
                WaitForCreation(command);
            }
        }

        private void WaitForCreation(IProduceUnitCommand command)
        {
            _creationStarted = true;
            _waitForCreationSlider.gameObject.SetActive(true);
            _waitForCreationSlider.OnValueChangedAsObservable().Where(value => value >= 1).Subscribe(value =>
            {
                _waitForCreationSlider.gameObject.SetActive(false);
                Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10)), Quaternion.identity, 
                    _unitsParent);
                _creationStarted = false;
                _waitForCreationSlider.value = 0;
            });
        }
        
        private void Update()
        {
            if (_creationStarted)
            {
                _waitForCreationSlider.value += 0.1f * Time.deltaTime;
            }
        }
    }
}
