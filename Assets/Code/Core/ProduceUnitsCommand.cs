using Code.Abstractions;
using Code.Utils;
using UnityEngine;
using Zenject;

namespace Code.Core
{
    public class ProduceUnitsCommand: IProduceUnitCommand
    {
        [Inject(Id = "Chomper")] public string UnitName { get; }
        [Inject(Id = "Chomper")] public Sprite Icon { get; }
        [Inject(Id = "Chomper")] public float ProductionTime { get; }
        
        [InjectAsset("Chomper")]private GameObject _unitPrefab;
        
        public GameObject UnitPrefab => _unitPrefab;
    }
}