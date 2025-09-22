using System;
using Cysharp.Threading.Tasks;
using Game.Services.InteractObjectService;
using Game.Services.TimerService;
using R3;
using Ui.UiCore;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>, IDisposable
    {
        private readonly IInteractObjectService _interactObjectService;
        private readonly ITimerService _timerService;
        private readonly CompositeDisposable _disposable = new ();
        
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
            
            ChangeLastActionTimerValue(TimeSpan.FromSeconds(_currentTimeForAction));
        }

        private async UniTask OnInteractButtonClicked()
        {
            while (true)
            {
                var result = await _timerService.StartTimer(_currentTimeForAction, ChangeLastActionTimerValue);

                if (result)
                {
                    ChangeLastActionTimerValue(TimeSpan.FromSeconds(_currentTimeForAction));
                    _interactObjectService.AddResourceFromObject();
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                    continue;
                }
                
                ChangeLastActionTimerValue(TimeSpan.FromSeconds(_currentTimeForAction));

                break;
            }
        }

        private void ChangeLastActionTimerValue(TimeSpan timerSpan)
        {
            View.LastActionTime.text = timerSpan.Seconds < 0 ? "00:00" : $"{timerSpan.Minutes:00}:{timerSpan.Seconds:00}";
            View.ActionTimeSlider.value = timerSpan.Seconds / _currentTimeForAction;
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}