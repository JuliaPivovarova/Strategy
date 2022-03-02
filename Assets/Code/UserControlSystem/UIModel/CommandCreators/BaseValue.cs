using System;
using Code.Abstractions;
using UniRx;
using UnityEngine;

namespace Code.UserControlSystem.UIModel.CommandCreators
{
    public abstract class BaseValue<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited>: AwaiterBase<TAwaited>
        {
            private readonly BaseValue<TAwaited> _baseValue;
            public NewValueNotifier(BaseValue<TAwaited> baseValue)
            {
                _baseValue = baseValue;
                _baseValue.OnNewValue += OnNewValue;
            }

            private void OnNewValue(TAwaited obj)
            {
                _baseValue.OnNewValue -= OnNewValue;
                OnFinish(obj);
            }
        }
        
        //public T CurrentValue { get; private set; }
        public ReactiveProperty<T> CurrentValue { get; private set; }
        public Action<T> OnNewValue;

        public void SetValue(T value)
        {
            CurrentValue.Value = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}