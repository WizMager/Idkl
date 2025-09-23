using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Services.InputService;
using R3;

namespace Game.Services.TimerService.Impl
{
    public class TimerService : ITimerService, IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource = new();
        private readonly IDisposable _disposable;

        public TimerService(IInputService inputService)
        {
            _disposable = inputService.IsMoveProperty.Subscribe(OnPlayerMoved);
        }
        
        private void OnPlayerMoved(bool isMoved)
        {
            if (isMoved)
                _cancellationTokenSource.Cancel();
        }

        public async UniTask<bool> StartTimer(float timer, Action<TimeSpan> timerStep = null)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var lastTime = timer;
            
            while (lastTime > 0)
            {
                try
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _cancellationTokenSource.Token);
                }
                catch (OperationCanceledException e)
                {
                    return false;
                }
                
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }
                
                lastTime -= 1f;
                timerStep?.Invoke(TimeSpan.FromSeconds(lastTime));
            }

            return true;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}