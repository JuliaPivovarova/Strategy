using UnityEngine;

namespace Code.Abstractions
{
    public interface IProduceUnitCommand: ICommand, IIconHolder
    {
        float ProductionTime { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }
    }
}