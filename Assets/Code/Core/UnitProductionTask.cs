using Code.Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class UnitProductionTask: IUnitProductionTask
    {
        public Sprite Icon { get; }
        public string UnitName { get; }
        public float TimeLeft { get; set; }
        public float ProductionTime { get; }
        public GameObject UnitPrefab { get; }
        
        public UnitProductionTask(float productionTime, Sprite icon, string unitName, GameObject unitPrefab)
        {
            ProductionTime = productionTime;
            TimeLeft = productionTime;
            Icon = icon;
            UnitName = unitName;
            UnitPrefab = unitPrefab;
        }

        
    }
}