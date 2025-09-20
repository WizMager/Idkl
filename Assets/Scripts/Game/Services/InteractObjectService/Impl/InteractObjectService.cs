using System;
using System.Collections.Generic;
using Game.Views.Interfaces;
using R3;
using Ui.Realization.InteractObjectStatusWindow;
using Ui.UiCore;
using Ui.UiManager;

namespace Game.Services.InteractObjectService.Impl
{
    public class InteractObjectService : IInteractObjectService, IDisposable
    {
        private readonly List<IInteractObject> _interactObjects = new();
        private readonly IUiManager _uiManager;
        private readonly CompositeDisposable _disposable = new ();
        
        private InteractObjectData _currentInteractObjectData;
        
        
        public InteractObjectService(
            IEnumerable<IInteractObject> interactObjects, 
            IUiManager uiManager//, 
            //IActivityStatusController activityStatusController
        )
        {
            foreach (var interactObject in interactObjects)
            {
                //_interactObjects.Add(interactObject);
                _disposable.Add(interactObject.OnPlayerEntered.Subscribe(OnPlayerEnteredInObject));
            }

            _uiManager = uiManager;
            //_activityStatusController = activityStatusController;
        }

        private void OnPlayerEnteredInObject(InteractObjectData interactObjectData)
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