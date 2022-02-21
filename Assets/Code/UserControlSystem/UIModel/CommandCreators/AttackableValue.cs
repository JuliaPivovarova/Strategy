using Code.Abstractions;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue: BaseValue<IAttackable>
    {
        
    }
}