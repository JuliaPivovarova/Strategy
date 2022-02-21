using System;
using System.Collections.Generic;
using System.Linq;
using Code.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UIView
{
    public class CommandButtonsView : MonoBehaviour
    {
        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _holdPositionButton;
        [SerializeField] private GameObject _produceUnitButton;

        public Action<ICommandExecutor> OnClick;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IHoldPositionCommand>), _holdPositionButton);
            _buttonsByExecutorType.Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                //var buttonGameObject = _buttonsByExecutorType
                    //.Where(type => type
                    //.Key
                    //.IsAssignableFrom(currentExecutor.GetType()))
                    //.First()
                    //.Value;
                    var buttonGameObject = GetButtonGameObjectByType(currentExecutor.GetType()); 
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }

        public void BlocInteractions(ICommandExecutor commandExecutor)
        {
            UnblocAllInteractions();
            GetButtonGameObjectByType(commandExecutor.GetType()).GetComponent<Selectable>().interactable = false;
        }

        private GameObject GetButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
                .Where(type => type.Key.IsAssignableFrom(executorInstanceType))
                .First()
                .Value;
        }

        public void UnblocAllInteractions() => SetInteractable(true);

        private void SetInteractable(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _holdPositionButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}