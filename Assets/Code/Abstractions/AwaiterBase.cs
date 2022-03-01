﻿using System;

namespace Code.Abstractions
{
    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        private bool _isCompleted;
        private Action _continuation;
        private TAwaited _result;

        public bool IsCompleted => _isCompleted;
        public TAwaited GetResult() => _result;
        
        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
                continuation?.Invoke();
            else
                _continuation = continuation;
        }

        protected void OnFinish(TAwaited result)
        {
            _result = result;
            _isCompleted = true;
            _continuation?.Invoke();
        }
    }
}