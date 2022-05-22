using System;
using UnityEngine;

namespace DevKacper.Timers
{
    public class TimerBehaviour : MonoBehaviour
    {
        public event Action OnTimerEnd;

        private float _time;

        public void SetupTimer(float time, Action OnTimerTimeOut)
        {
            _time = time;
            OnTimerEnd = OnTimerTimeOut;
        }

        private void Update()
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                return;
            }

            DestroyTimer();
        }

        private void DestroyTimer()
        {
            OnTimerEnd?.Invoke();
            Destroy(this);
        }

        public float GetTime()
        {
            return _time;
        }
    }
}