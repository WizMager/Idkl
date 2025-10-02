using System;
using System.Collections.Generic;
using Data.ItemsData;
using Game.Services.ItemStorageService;
using R3;
using Ui.Realization.InteractObjectStatusWindow;
using Ui.UiCore;
using Ui.WindowChanger;
using UnityEngine;
using Utils.InteractObjectProvider;
using Utils.ItemTypeHelper;
using Object = UnityEngine.Object;

namespace Game.Services.InteractObjectService.Impl
{
    public class InteractObjectService : IInteractObjectService, IDisposable
    {
        private readonly IUiWindowChanger _uiWindowChanger;
        private readonly CompositeDisposable _disposable = new ();
        private readonly Dictionary<EInteractObject, EItemType> _chosenItemInInteractObjects = new();
        private readonly IItemData _itemData;
        private readonly IItemStorageService _itemStorageService;
        
        private InteractObjectData _currentInteractObjectData;
        
        public InteractObjectService(
            IInteractObjectsProvider interactObjectsProvider,
            IUiWindowChanger uiWindowChanger, 
            IItemData itemData, 
            IItemStorageService itemStorageService
        )
        {
            foreach (var interactObject in interactObjectsProvider.GetInteractObjects())
            {
                _disposable.Add(interactObject.OnPlayerEntered.Subscribe(OnPlayerEnteredInObject));
                _disposable.Add(interactObject.OnPlayerExited.Subscribe(OnPlayerExitedFromObject));
            }

            _uiWindowChanger = uiWindowChanger;
            _itemData = itemData;
            _itemStorageService = itemStorageService;

            InitDefaultChosenItems();
        }

        private void InitDefaultChosenItems()
        {
            foreach (var itemObjectPair in _itemData.GetDefaultItems)
            {
                _chosenItemInInteractObjects.Add(itemObjectPair.InteractObject, itemObjectPair.ItemType);
            }
        }

        private void OnPlayerEnteredInObject(InteractObjectData interactObjectData)
        {
            _currentInteractObjectData = interactObjectData;
            _uiWindowChanger.OpenPopupWindow(EWindowName.InteractObjectStatus);
        }
        
        private void OnPlayerExitedFromObject(Unit _)
        {
            _uiWindowChanger.ClosePopupWindow();
        }
        
        public InteractObjectData GetCurrentInteractObjectData()
        {
            return _currentInteractObjectData;
        }
        
        public void AddResourceFromObject()
        {
            _itemStorageService.AddItem(GetCurrentItemFromObject());
        }
        
        private EItemType GetCurrentItemFromObject()
        {
            return _chosenItemInInteractObjects[_currentInteractObjectData.InteractObjectName];
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}