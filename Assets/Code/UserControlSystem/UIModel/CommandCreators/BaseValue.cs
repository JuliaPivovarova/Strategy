using System;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public abstract class BaseValue<T> : ScriptableObject
    {
        public T CurrentValue { get; private set; }
        public Action<T> OnNewValue;

        public void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }
    }
}