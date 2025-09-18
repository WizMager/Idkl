using System;
using Game.Ui.GameHudWindow;
using Game.Ui.InteractObjectStatusWindow;
using Reflex.Core;
using UiCore;
using UnityEngine;

namespace Game.Installers
{
    public class UiInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private InteractObjectStatusView _interactObjectStatusView;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            var canvasTransform = _canvas.transform;
            
            var gameHudView = Instantiate(_gameHudView, canvasTransform);
            containerBuilder.AddSingleton(gameHudView, typeof(GameHudView));
            containerBuilder.AddSingleton(typeof(GameHudController));
            containerBuilder.AddSingleton(typeof(GameHudWindow), typeof(AWindow));
            
            var interactObjectStatusView = Instantiate(_interactObjectStatusView, canvasTransform);
            containerBuilder.AddSingleton(interactObjectStatusView, typeof(InteractObjectStatusView));
            containerBuilder.AddSingleton(typeof(InteractObjectStatusController));
            containerBuilder.AddSingleton(typeof(InteractObjectStatusWindow), typeof(AWindow));
        }

        //TODO: complete something like this for more clean code for setup windows
        private void SetupWindow<TWindow>(AWindowView view, ContainerBuilder containerBuilder, Transform canvasTransform, Type controllerType) 
            where TWindow : AWindow
        {
            var settingsView = Instantiate(view, canvasTransform);
            containerBuilder.AddSingleton(settingsView, typeof(AWindowView));
            containerBuilder.AddSingleton(controllerType);
            containerBuilder.AddSingleton(typeof(TWindow), typeof(AWindow));
        }
    }
}