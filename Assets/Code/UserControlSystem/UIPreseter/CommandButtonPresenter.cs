using System.Collections.Generic;
using Code.Abstractions;
using Code.UserControlSystem.UIModel;
using Code.UserControlSystem.UIModel.CommandCreators;
using Code.UserControlSystem.UIView;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIPreseter
{
    public class CommandButtonPresenter: MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;

        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandAccepted += _view.BlocInteractions;
            _model.OnCommandSent += _view.UnblocAllInteractions;
            _model.OnCommandCancel += _view.UnblocAllInteractions;
            
            _selectable.OnNewValue += OnSelected;
            OnSelected(_selectable.CurrentValue);
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }

            _currentSelectable = selectable;
            
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutor = new List<ICommandExecutor>();
                commandExecutor.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutor);
            }
        }
    }
}