using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data.ItemsData;
using Game.Services.InteractObjectService;
using Game.Services.TimerService;
using R3;
using Ui.UiCore;
using UnityEngine;
using Utils.ItemTypeHelper;
using Object = UnityEngine.Object;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>, IDisposable
    {
        private readonly IInteractObjectService _interactObjectService;
        private readonly ITimerService _timerService;
        private readonly IItemData _itemData;
        private readonly CompositeDisposable _disposable = new ();
        private readonly Dictionary<EInteractObject, CraftItem[]> _craftItems = new ();
        private readonly Transform _craftItemsContainer;

        private float _currentTimeForAction;
        
        public InteractObjectStatusController(
            InteractObjectStatusView view,
            IInteractObjectService interactObjectService,
            ITimerService timerService, 
            IItemData itemData
        ) : base(view)
        {
            _interactObjectService = interactObjectService;
            _timerService = timerService;
            _itemData = itemData;

            _craftItemsContainer = new GameObject("CraftItemsContainer").transform;
            View.InteractButton.OnClickAsObservable().Subscribe(_ => OnInteractButtonClicked().Forget()).AddTo(_disposable);
        }

        protected override void OnShow()
        {
            var interactObject = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName;
            
            if (!_craftItems.ContainsKey(interactObject))
            {
                var craftItems = new List<CraftItem>();
                
                foreach (var eItemType in ItemTypeMapper.GetItemsByInteractObject(_interactObjectService.GetCurrentInteractObjectData().InteractObjectName))
                {
                    var craftItem = Object.Instantiate(_itemData.CraftItem).GetComponent<CraftItem>();
                    craftItem.Init(_itemData.GetItemIcon(eItemType), eItemType, View.ScrollViewContentTransform);
                    
                    craftItems.Add(craftItem);
                }
                
                _craftItems.Add(interactObject, craftItems.ToArray());
            }
            else
            {
                foreach (var craftItem in _craftItems[interactObject])
                {
                    craftItem.Activate(View.ScrollViewContentTransform);
                }
            }
            
            View.ObjectName.text = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName.ToString();
            _currentTimeForAction = _interactObjectService.GetCurrentInteractObjectData().BaseTimeForAction;
            
            var timer = TimeSpan.FromSeconds(_currentTimeForAction);
            View.ObjectActionTime.text = $"{timer.Minutes:00}:{timer.Seconds:00}";
            
            ChangeLastActionTimerValue(TimeSpan.FromSeconds(_currentTimeForAction));
        }

        protected override void OnHide()
        {
            if (_craftItems.Count == 0)
                return;
            
            var interactObject = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName;
            
            foreach (var craftItem in _craftItems[interactObject])
            {
                craftItem.Deactivate(_craftItemsContainer);
            }
        }

        private async UniTask OnInteractButtonClicked()
        {
            while (true)
            {
                var result = await _timerService.StartTimer(_currentTimeForAction, ChangeLastActionTimerValue);

                if (result)
                {
                    _interactObjectService.AddResourceFromObject();
                    
                    await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                    
                    ChangeLastActionTimerValue(TimeSpan.FromSeconds(_currentTimeForAction));
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