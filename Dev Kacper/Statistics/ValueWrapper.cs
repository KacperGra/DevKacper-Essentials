using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Mechanic
{
    public class ValueWrapper<TValue>
    {
        public event Action<TValue> OnValueChanged = null;

        private TValue _lastValue;
        private TValue _value;

        public ValueWrapper()
        {
            _value = default;
        }

        public ValueWrapper(TValue value)
        {
            _value = value;
        }

        public void Set(TValue value)
        {
            _lastValue = value;
            _value = value;

            OnValueChanged?.Invoke(_value);
        }

        public TValue GetLastValue()
        {
            return _lastValue;
        }

        public TValue GetValue()
        {
            return _value;
        }
    }
}