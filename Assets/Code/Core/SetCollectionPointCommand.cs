using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class SetCollectionPointCommand: ISetCollectionPointCommand
    {
        public Vector3 CollectionPoint { get; }

        public SetCollectionPointCommand(Vector3 collectionPoint)
        {
            CollectionPoint = collectionPoint;
        }
    }
}