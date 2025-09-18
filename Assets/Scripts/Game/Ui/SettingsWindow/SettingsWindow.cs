using Reflex.Core;
using UiCore;

namespace Game.Ui.SettingsWindow
{
    public class SettingsWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.Settings;
        
        public SettingsWindow(Container containerBuilder) : base(containerBuilder)
        {
        }
        
        public override void AddControllers()
        {
            AddController<SettingsController>();
        }
    }
}