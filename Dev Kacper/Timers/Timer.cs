using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Timers
{
    public class Timer
    {
        private Action _onTimerEnd;
        private float _time;

        public Timer()
        { }

        public Timer(float time, Action onTimerEnd)
        {
            SetupTimer(time, onTimerEnd);
        }

        public void SetupTimer(float time, Action onTimerEndAction = null)
        {
            _time = time;
            _onTimerEnd = onTimerEndAction;
        }

        public void Update(float deltaTime)
        {
            if (_time > 0)
            {
                _time -= deltaTime;
                return;
            }

            _onTimerEnd?.Invoke();
        }

        public float GetTime()
        {
            return _time;
        }
    }
}