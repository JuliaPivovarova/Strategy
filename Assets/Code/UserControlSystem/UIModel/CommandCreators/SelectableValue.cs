using Code.Abstractions;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : BaseValue<ISelectable>
    {
        
    }
}
