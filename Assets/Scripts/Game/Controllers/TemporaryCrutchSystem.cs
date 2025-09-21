using Game.Services.InteractObjectService;
using GameLoop.Interfaces;
using Generator;
using Ui.UiManager;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 69)]
    public class TemporaryCrutchSystem : IController
    {
        public TemporaryCrutchSystem(IInteractObjectService interactObjectService, IUiManager uiManager)
        {
            
        }
    }
}