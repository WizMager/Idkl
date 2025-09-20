using System;
using System.Collections.Generic;
using Game.Services.InteractObjectService;
using Game.Views.Interfaces;
using R3;
using Ui.UiCore;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>, IDisposable
    {
        private readonly CompositeDisposable _disposable = new ();
        
        public InteractObjectStatusController(
            InteractObjectStatusView view,
            IEnumerable<IInteractObject> interactObjects
        ) : base(view)
        {
            foreach (var interactObject in interactObjects)
            {
                _disposable.Add(interactObject.OnPlayerEntered.Subscribe(OnPlayerEnteredInObject));
            }
        }

        private void OnPlayerEnteredInObject(InteractObjectData interactObjectData)
        {
            View.ObjectName.text = interactObjectData.InteractObjectName.ToString();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}