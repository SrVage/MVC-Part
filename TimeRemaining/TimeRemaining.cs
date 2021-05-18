using System;
using UnityEngine;

namespace Code.BonusGame.TimeRemaining
{
    public sealed class TimeRemaining:ITimeRemaining
    {
        public Action Method { get; }
        public float Time { get; }
        public float CurrentTime { get; set; }

        public TimeRemaining(Action method, float time)
        {
            Method = method;
            Time = time;
            CurrentTime = time;
        }
    }
}