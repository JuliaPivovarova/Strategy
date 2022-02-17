using UnityEngine;

namespace Code.Abstractions
{
    public interface IProduceUnitCommand: ICommand
    {
        GameObject UnitPrefab { get; }
    }
}