using Code.Abstractions;
using Code.Utils;
using UnityEngine;

namespace Code.UserControlSystem
{
    public class ProduceUnitsCommand: IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;

        [InjectAsset("Chomper")]private GameObject _unitPrefab;
    }
}