using Game.Services.UiManager;
using GameLoop.Interfaces;
using Generator;
using UiCore;

namespace Game.Controllers
{
    [Install(EExecutionPriority.High, 10)]
    public class GameInitializeController : IStartable
    {
        private readonly IUiManager _uiManager;
        
        public GameInitializeController(IUiManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        public void Start()
        {
            _uiManager.OpenWindow(EWindowName.GameHud);
        }
    }
}