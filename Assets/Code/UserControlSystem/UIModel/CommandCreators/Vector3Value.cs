using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public class Vector3Value : BaseValue<Vector3>
    {
    }
}