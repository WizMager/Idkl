using System;
using Cysharp.Threading.Tasks;

namespace Game.Services.TimerService
{
    public interface ITimerService
    {
        UniTask<bool> StartTimer(float timer, Action<TimeSpan> timerStep = null);
    }
}