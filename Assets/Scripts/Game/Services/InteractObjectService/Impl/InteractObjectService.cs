using System;
using R3;
using Ui.UiCore;
using Ui.WindowChanger;
using Utils.InteractObjectProvider;

namespace Game.Services.InteractObjectService.Impl
{
    public class InteractObjectService : IInteractObjectService, IDisposable
    {
        private readonly IUiWindowChanger _uiWindowChanger;
        private readonly CompositeDisposable _disposable = new ();
        
        private InteractObjectData _currentInteractObjectData;
        
        public InteractObjectService(
            IInteractObjectsProvider interactObjectsProvider,
            IUiWindowChanger uiWindowChanger
        )
        {
            foreach (var interactObject in interactObjectsProvider.GetInteractObjects())
            {
                _disposable.Add(interactObject.OnPlayerEntered.Subscribe(OnPlayerEnteredInObject));
                _disposable.Add(interactObject.OnPlayerExited.Subscribe(OnPlayerExitedFromObject));
            }

            _uiWindowChanger = uiWindowChanger;
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
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}