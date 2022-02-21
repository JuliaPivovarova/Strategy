using UnityEngine;

namespace Code.Abstractions
{
    public interface ISelectable: IHealthHolder
    {
        Transform StayPoint { get; }
        Sprite Icon { get; }
    }
}
