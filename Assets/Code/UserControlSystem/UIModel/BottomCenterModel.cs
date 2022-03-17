using System;
using Code.Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UIModel
{
    public class BottomCenterModel
    {
        public IObservable<IUnitProducer> UnitProducer { get; private set; }

        [Inject]
        public void Init(IObservable<ISelectable> currentlySelected)
        {
            UnitProducer = currentlySelected
                .Select(selectable => selectable as Component)
                .Select(component => component?.GetComponent<IUnitProducer>());
        }
    }
}