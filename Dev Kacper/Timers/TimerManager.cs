using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevKacper.Timers
{
    public class TimerManager : Singleton<TimerManager>
    {
        private event Action<float> _onUpdate;

        private List<TimerBehaviour> _timers = new List<TimerBehaviour>();

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _onUpdate?.Invoke(deltaTime);
        }

        public void AddTimer(TimerBehaviour timer)
        {
            _onUpdate += timer.Update;
            _timers.Add(timer);
        }

        public void RemoveTimer(TimerBehaviour timer)
        {
            _onUpdate -= timer.Update;
            _timers.Remove(timer);
        }
    }
}