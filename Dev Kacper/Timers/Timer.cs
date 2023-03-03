using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Timers
{
    public class Timer
    {
        public event Action OnFinished;

        private float _time;
        private float _startingTime;

        private bool _resetOnFinish;
        private bool _isFinished;

        public bool ResetOnFinish
        {
            get => _resetOnFinish;
            set => _resetOnFinish = value;
        }

        public Timer(float time, Action onFinished)
        {
            _startingTime = time;
            _time = time;
            OnFinished = onFinished;
            _isFinished = false;
            _resetOnFinish = false;
        }

        public void Update(float time)
        {
            if (_isFinished)
            {
                return;
            }

            if (_time > 0)
            {
                _time -= time;
                return;
            }

            OnFinished?.Invoke();
            _isFinished = true;
            if (_resetOnFinish)
            {
                _isFinished = false;
                _time = _startingTime;
            }
        }

        public float GetTime()
        {
            return _time;
        }
    }
}