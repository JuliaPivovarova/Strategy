using UnityEngine;

namespace Code.Abstractions
{
    public interface ISelectable: IHealthHolder, IIconHolder
    {
        Transform StayPoint { get; }
    }
}
