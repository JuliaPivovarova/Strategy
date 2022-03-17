using UnityEngine;

namespace Code.Abstractions
{
    public interface ISetCollectionPointCommand: ICommand
    {
        Vector3 CollectionPoint { get; }
    }
}