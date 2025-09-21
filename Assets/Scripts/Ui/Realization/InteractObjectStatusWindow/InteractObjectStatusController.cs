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
        private readonly IInteractObjectService _interactObjectService;
        private readonly CompositeDisposable _disposable = new ();
        
        public InteractObjectStatusController(
            InteractObjectStatusView view,
            IInteractObjectService interactObjectService
        ) : base(view)
        {
            _interactObjectService = interactObjectService;
        }

        protected override void OnShow()
        {
            View.ObjectName.text = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName.ToString();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}