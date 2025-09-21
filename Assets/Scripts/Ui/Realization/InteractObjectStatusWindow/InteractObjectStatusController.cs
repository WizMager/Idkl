using System;
using System.Globalization;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Services.InteractObjectService;
using Game.Services.TimerService;
using R3;
using Ui.UiCore;
using UnityEngine;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>, IDisposable
    {
        private readonly IInteractObjectService _interactObjectService;
        private readonly ITimerService _timerService;
        private readonly CompositeDisposable _disposable = new ();
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        
        private float _currentTimeForAction;
        
        public InteractObjectStatusController(
            InteractObjectStatusView view,
            IInteractObjectService interactObjectService,
            ITimerService timerService
        ) : base(view)
        {
            _interactObjectService = interactObjectService;
            _timerService = timerService;

            View.InteractButton.OnClickAsObservable().Subscribe(_ => OnInteractButtonClicked().Forget()).AddTo(_disposable);
        }

        protected override void OnShow()
        {
            View.ObjectName.text = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName.ToString();
            _currentTimeForAction = _interactObjectService.GetCurrentInteractObjectData().BaseTimeForAction;
            var timer = TimeSpan.FromSeconds(_currentTimeForAction);
            View.ObjectActionTime.text = $"{timer.Minutes:00}:{timer.Seconds:00}";
            SetLastActionText(TimeSpan.FromSeconds(_currentTimeForAction));
        }

        private async UniTask OnInteractButtonClicked()
        {
            while (true)
            {
                var result = await _timerService.StartTimer(_currentTimeForAction, SetLastActionText);

                if (result)
                {
                    SetLastActionText(TimeSpan.FromSeconds(_currentTimeForAction));
                    Debug.Log("Add some resources");
                    //TODO: Add some resources
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                    continue;
                }
                
                SetLastActionText(TimeSpan.FromSeconds(_currentTimeForAction));

                break;
            }
        }

        private void SetLastActionText(TimeSpan timerSpan)
        {
            View.LastActionTime.text = timerSpan.Seconds < 0 ? "00:00" : $"{timerSpan.Minutes:00}:{timerSpan.Seconds:00}";
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}