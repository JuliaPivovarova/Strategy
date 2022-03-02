using Code.Abstractions;
using Code.UserControlSystem.UIModel;
using Code.UserControlSystem.UIModel.CommandCreators;
using Code.UserControlSystem.UIView;
using UnityEngine;

namespace Code.UserControlSystem.UIPreseter
{
    public class OutlineSelectPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedObject;
    
        private OutlineSelectView[] _outlineSelects;
        private ISelectable _selected;

        private void Start()
        {
            _selectedObject.OnNewValue += SetSelected;
            SetSelected(_selectedObject.CurrentValue.Value);
        }
    
        private void SetSelected(ISelectable selectable)
        {
            if (_selected == selectable)
                return;

            _selected = selectable;
        
            SetSelected(_outlineSelects, false);
            _outlineSelects = null;

            if (_selectedObject != null)
            {
                _outlineSelects = (selectable as Component)?.GetComponentsInChildren<OutlineSelectView>();
                SetSelected(_outlineSelects, true);
            }
        }

        private void SetSelected(OutlineSelectView[] selects, bool isSelected)
        {
            if (selects != null)
            {
                for (int i = 0; i < selects.Length; i++)
                {
                    selects[i].SetSelected(isSelected);
                }
            }
        }
    }
}
