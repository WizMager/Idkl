using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Services.TimerService
{
    public interface ITimerService
    {
        UniTask<bool> StartTimer(float timer, Action<TimeSpan> timerStep = null, CancellationTokenSource cancellationTokenSource = null);
    }
}