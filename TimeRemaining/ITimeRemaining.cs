using System;

namespace Code.BonusGame.TimeRemaining
{
    public interface ITimeRemaining
    {
        Action Method { get; }
        float Time { get; }
        float CurrentTime { get; set; }
    }
}