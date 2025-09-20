using Reflex.Core;
using Ui.UiCore;

namespace Ui.Realization.SettingsWindow
{
    public class SettingsWindow : AWindow
    {
        public override EWindowName WindowName => EWindowName.Settings;
        
        public SettingsWindow(Container container) : base(container)
        {
        }
        
        public override void AddControllers()
        {
            AddController<SettingsController>();
        }
    }
}