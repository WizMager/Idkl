using Reflex.Core;
using UiCore;

namespace Game.Ui.GameHudWindow
{
    public class GameHudWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.GameHud;
        
        public GameHudWindow(Container containerBuilder) : base(containerBuilder)
        {
        }
        
        public override void AddControllers()
        {
            AddController<GameHudController>();
        }
    }
}