using Game.Services.InteractObjectService;
using UiCore;

namespace Game.Ui.InteractObjectStatusWindow
{
    public class InteractObjectStatusController : AWindowController<InteractObjectStatusView>, IInteractObjectController
    {
        public InteractObjectStatusController(InteractObjectStatusView view) : base(view)
        {
        }

        public void SetInteractObjectData(InteractObjectData interactObjectData)
        {
            View.ObjectName.text = interactObjectData.InteractObjectName.ToString();
        }
    }
}