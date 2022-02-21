using Code.Abstractions;
using UnityEngine;

namespace Code.UserControlSystem
{
    public class HoldPositionCommand : IHoldPositionCommand
    {
        public Vector3 PositionToHold { get; }
        public HoldPositionCommand(Vector3 positionToHold)
        {
            PositionToHold = positionToHold;
        }
    }
}
