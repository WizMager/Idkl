using GameLoop.Interfaces;
using Generator;
using Ui.UiCore;
using Ui.WindowChanger;

namespace Game.Controllers
{
    [Install(EExecutionPriority.High, 10)]
    public class GameInitializeController : IStartable
    {
        private readonly IUiWindowChanger _uiWindowChanger;
        
        public GameInitializeController(IUiWindowChanger uiWindowChanger)
        {
            _uiWindowChanger = uiWindowChanger;
        }
        
        public void Start()
        {
            _uiWindowChanger.OpenWindow(EWindowName.GameHud);
        }
    }
}