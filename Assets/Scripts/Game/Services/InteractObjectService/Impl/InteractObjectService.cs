using System;
using System.Collections.Generic;
using Game.Services.UiManager;
using Game.Ui.InteractObjectStatusWindow;
using Game.Views.Interfaces;
using R3;
using UnityEngine;

namespace Game.Services.InteractObjectService.Impl
{
    public class InteractObjectService : IInteractObjectService, IDisposable
    {
        private readonly List<IInteractObject> _interactObjects = new();

        private readonly CompositeDisposable _disposable = new ();
        private InteractObjectData _currentInteractObjectData;
        private readonly IInteractObjectController _interactObjectController;
        
        public InteractObjectService(IEnumerable<IInteractObject> interactObjects, IInteractObjectController interactObjectController)
        {
            foreach (var interactObject in interactObjects)
            {
                //_interactObjects.Add(interactObject);
                Debug.Log("init");
                _disposable.Add(interactObject.OnPlayerEntered.Subscribe(OnPlayerEnteredInObject));
            }

            _interactObjectController = interactObjectController;
        }

        private void OnPlayerEnteredInObject(InteractObjectData interactObjectData)
        {
            Debug.Log("InteractObjectService: OnPlayerEnteredInObject");
            _currentInteractObjectData = interactObjectData;
            _interactObjectController.SetInteractObjectData(interactObjectData);
        }
        
        public InteractObjectData GetCurrentInteractObjectData()
        {
            return _currentInteractObjectData;
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}