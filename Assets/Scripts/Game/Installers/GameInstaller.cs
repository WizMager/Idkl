using Game.Services.InputService;
using Game.Services.InputService.Impl;
using Game.Services.InteractObjectService;
using Game.Services.InteractObjectService.Impl;
using Reflex.Core;
using Ui.UiManager;
using Ui.UiManager.Impl;
using Ui.WindowChanger;
using Ui.WindowChanger.Impl;
using UnityEngine;
using Utils.GameSceneObjectsProvider;
using Utils.GameSceneObjectsProvider.Impl;
using Utils.InteractObjectProvider;

namespace Game.Installers
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameSceneObjects _gameSceneObjects;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(InputService), typeof(IInputService));
            containerBuilder.AddSingleton(new GameSceneObjectsProvider(_gameSceneObjects), typeof(IGameSceneObjectsProvider));
            containerBuilder.AddSingleton(new InteractObjectsProvider(_gameSceneObjects.InteractObjects), typeof(IInteractObjectsProvider));
            containerBuilder.AddSingleton(typeof(UiManager), typeof(IUiManager));
            containerBuilder.AddSingleton(typeof(UiWindowChanger), typeof(IUiWindowChanger));
            containerBuilder.AddSingleton(typeof(InteractObjectService), typeof(IInteractObjectService));
        }
    }
}