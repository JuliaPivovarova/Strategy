using UnityEngine;

namespace Code.Abstractions
{
    public interface IMoveCommand: ICommand
    {
        public Vector3 Target { get; }
    }
}