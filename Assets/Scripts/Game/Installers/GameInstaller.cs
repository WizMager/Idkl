using Game.Services.InputService;
using Game.Services.InputService.Impl;
using Game.Services.InteractObjectService;
using Game.Services.InteractObjectService.Impl;
using Game.Views.Interfaces;
using Reflex.Core;
using Ui.UiManager;
using Ui.UiManager.Impl;
using UnityEngine;
using Utils.GameSceneObjectsProvider;
using Utils.GameSceneObjectsProvider.Impl;

namespace Game.Installers
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameSceneObjects _gameSceneObjects;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(InputService), typeof(IInputService));
            containerBuilder.AddSingleton(new GameSceneObjectsProvider(_gameSceneObjects), typeof(IGameSceneObjectsProvider));
            foreach (var interactObject in _gameSceneObjects.InteractObjects)
            {
                containerBuilder.AddSingleton(interactObject, typeof(IInteractObject));
            }
            containerBuilder.AddSingleton(typeof(UiManager), typeof(IUiManager));
            containerBuilder.AddSingleton(typeof(InteractObjectService), typeof(IInteractObjectService));
        }
    }
}