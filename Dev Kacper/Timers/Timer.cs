using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Timers
{
    public class Timer
    {
        private float time;
        private Action[] OnTimerEnd;

        public Timer() { }

        public Timer(float time, Action onTimerEnd)
        {
            SetupTimer(time, onTimerEnd);
        }

        public Timer(float time, Action[] onTimerEnd)
        {
            SetupTimer(time, onTimerEnd);
        }

        public void SetupTimer(float time, Action onTimerEnd = null)
        {
            this.time = time;
            this.OnTimerEnd = new Action[1];
            this.OnTimerEnd[0] = onTimerEnd;
        }
        public void SetupTimer(float time, Action[] onTimerEnd = null)
        {
            this.time = time;
            this.OnTimerEnd = onTimerEnd;
        }

        public void Update(float deltaTime)
        {
            if (time > 0)
            {
                time -= deltaTime;
            }
            else
            {
                TimerInvoke();
            }
        }

        private void TimerInvoke()
        {
            if(OnTimerEnd == null)
            {
                return;
            }

            foreach(Action action in OnTimerEnd)
            {
                action?.Invoke();
            }
        }

        public float GetTime()
        {
            return time;
        }
    }
}