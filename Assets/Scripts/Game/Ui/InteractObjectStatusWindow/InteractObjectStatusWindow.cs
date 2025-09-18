using Reflex.Core;
using UiCore;

namespace Game.Ui.InteractObjectStatusWindow
{
    public class InteractObjectStatusWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.InteractObjectStatus;
        
        public InteractObjectStatusWindow(Container containerBuilder) : base(containerBuilder)
        {
        }
        
        public override void AddControllers()
        {
            AddController<InteractObjectStatusController>();
        }
    }
}