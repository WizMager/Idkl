using Game.Services.InteractObjectService;
using UiCore;

namespace Game.Ui.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>
    {
        private readonly IInteractObjectService _interactObjectService;
        
        public InteractObjectStatusController(
            InteractObjectStatusView view//, 
            //IInteractObjectService interactObjectService
        ) : base(view)
        {
            //_interactObjectService = interactObjectService;
        }

        protected override void OnShow()
        {
            base.OnShow();
            
            //View.ObjectName.text = _interactObjectService.GetCurrentInteractObjectData().InteractObjectName.ToString();
        }
    }
}