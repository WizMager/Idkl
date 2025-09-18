using System;
using System.Collections.Generic;
using Game.Services.UiManager;
using Game.Views.Interfaces;
using R3;
using UiCore;

namespace Game.Services.InteractObjectService.Impl
{
    public class InteractObjectService : IInteractObjectService, IDisposable
    {
        private readonly List<IInteractObject> _interactObjects = new();
        private readonly IUiManager _uiManager;

        private readonly CompositeDisposable _disposable = new ();
        private InteractObjectData _currentInteractObjectData;
        
        public InteractObjectService(IEnumerable<IInteractObject> interactObjects, IUiManager uiManager)
        {
            foreach (var interactObject in interactObjects)
            {
                _interactObjects.Add(interactObject);
                _disposable.Add(interactObject.OnMouseOver.Subscribe(OnInteractObjectMouseOver));
            }

            _uiManager = uiManager;
        }

        private void OnInteractObjectMouseOver(InteractObjectData interactObjectData)
        {
            _currentInteractObjectData = interactObjectData;
            
            _uiManager.OpenPopupWindow(EWindowName.InteractObjectStatus);
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