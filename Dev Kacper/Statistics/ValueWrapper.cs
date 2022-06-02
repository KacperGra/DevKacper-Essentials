using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Mechanic
{
    public class ValueWrapper<TValue>
    {
        private Action<TValue> _onValueChanged = null;

        private TValue _lastValue;
        private TValue _value;

        public ValueWrapper()
        {
            _value = default(TValue);
        }

        public ValueWrapper(TValue value)
        {
            _value = value;
        }

        public void Set(TValue value)
        {
            _lastValue = value;
            _value = value;

            _onValueChanged?.Invoke(_value);
        }

        public void AddChangeListener(Action<TValue> callback)
        {
            _onValueChanged += callback;
        }

        public void RemoveChangeListener(Action<TValue> callback)
        {
            _onValueChanged += callback;
        }

        public TValue GetLastValue()
        {
            return _lastValue;
        }

        public TValue GetValue()
        {
            return _value;
        }

        public bool Is(TValue value)
        {
            return _value != null && _value.Equals(value);
        }
    }
}