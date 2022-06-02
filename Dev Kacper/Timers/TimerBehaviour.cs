using System;
using UnityEngine;

namespace DevKacper.Timers
{
    public class TimerBehaviour : Timer
    {
        #region Static

        public static TimerBehaviour Create(float time, Action onFinished, string name = "")
        {
            TimerBehaviour timer = new TimerBehaviour(time, onFinished)
            {
                _name = name
            };

            TimerManager.Instance.AddTimer(timer);

            return timer;
        }

        public static void DestroyTimer(TimerBehaviour timer)
        {
            TimerManager.Instance.RemoveTimer(timer);
        }

        #endregion Static

        public string Name => _name;

        private string _name;

        public TimerBehaviour(float time, Action onFinished) : base(time, onFinished)
        {
        }
    }
}