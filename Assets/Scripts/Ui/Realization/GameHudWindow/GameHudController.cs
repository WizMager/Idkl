using System;
using Ui.UiCore;

namespace Ui.Realization.GameHudWindow
{
    public class GameHudController : AWindowController<GameHudView>
    {
        private readonly IDisposable _disposable;
        
        public GameHudController(GameHudView view) : base(view)
        {
        }
    }
}