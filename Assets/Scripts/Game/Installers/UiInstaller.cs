using Reflex.Core;
using Ui.Realization.GameHudWindow;
using Ui.Realization.InteractObjectStatusWindow;
using Ui.UiCore;
using UnityEngine;

namespace Game.Installers
{
    public class UiInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private InteractObjectStatusView _interactObjectStatusView;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            SetupWindow<GameHudWindow, GameHudController>(_gameHudView, containerBuilder);
            SetupWindow<InteractObjectStatusWindow, InteractObjectStatusController>(_interactObjectStatusView, containerBuilder);
        }
        
        private void SetupWindow<TWindow, TController>(AWindowView view, ContainerBuilder containerBuilder) 
            where TWindow : AWindow
            where TController : IWindowController
        {
            var viewInstance = Instantiate(view, _canvasTransform);
            containerBuilder.AddSingleton(viewInstance, typeof(AWindowView), view.GetType());
            containerBuilder.AddSingleton(typeof(TController));
            containerBuilder.AddSingleton(typeof(TWindow), typeof(AWindow));
        }
    }
}