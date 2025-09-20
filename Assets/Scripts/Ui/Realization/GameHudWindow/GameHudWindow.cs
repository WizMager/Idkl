using Reflex.Core;
using Ui.UiCore;

namespace Ui.Realization.GameHudWindow
{
    public class GameHudWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.GameHud;
        
        public GameHudWindow(Container container) : base(container)
        {
        }
        
        public override void AddControllers()
        {
            AddController<GameHudController>();
        }
    }
}