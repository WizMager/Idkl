using Reflex.Core;
using Ui.UiCore;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class InteractObjectStatusWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.InteractObjectStatus;
        
        public InteractObjectStatusWindow(Container container) : base(container)
        {
        }
        
        public override void AddControllers()
        {
            AddController<InteractObjectStatusController>();
        }
    }
}