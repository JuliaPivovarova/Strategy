using System.Collections;
using System.Threading.Tasks;
using Code.Abstractions;
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
        private bool _isCreating;

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
            WaitForCreation(command);
        }

        private async void WaitForCreation(IProduceUnitCommand command)
        {
            _isCreating = true;
            //_waitForCreationSlider.gameObject.SetActive(true);
            //WaitForSlider();
            await Task.Delay(1000);
            
            _waitForCreationSlider.gameObject.SetActive(false);
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10)), Quaternion.identity, 
                _unitsParent);
        }

        private void WaitForSlider()
        {
            while (_waitForCreationSlider.value < _waitForCreationSlider.maxValue)
            {
                _waitForCreationSlider.value += 0.001f * Time.deltaTime;
            }
            if (_waitForCreationSlider.value >= _waitForCreationSlider.maxValue)
            {
                _isCreating = false;
            }
        }
    }
}
