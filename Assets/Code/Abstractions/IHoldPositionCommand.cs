using UnityEngine;

namespace Code.Abstractions
{
    public interface IHoldPositionCommand: ICommand
    {
        Vector3 PositionToHold { get; }
    }
}