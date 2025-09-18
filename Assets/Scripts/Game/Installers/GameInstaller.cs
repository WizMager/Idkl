using Game.Services.GameSceneObjectsProvider;
using Game.Services.GameSceneObjectsProvider.Impl;
using Game.Services.InputService;
using Game.Services.InputService.Impl;
using Game.Services.InteractObjectService;
using Game.Services.InteractObjectService.Impl;
using Game.Services.UiManager;
using Game.Services.UiManager.Impl;
using Game.Views.Interfaces;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private GameSceneObjects _gameSceneObjects;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(typeof(InputService), typeof(IInputService));
            containerBuilder.AddSingleton(new GameSceneObjectsProvider(_gameSceneObjects),
                typeof(IGameSceneObjectsProvider));
            containerBuilder.AddSingleton(typeof(UiManager), typeof(IUiManager));
            var interactObjects = _gameSceneObjects.InteractObjects;
            foreach (var interactObject in interactObjects)
            {

                containerBuilder.AddSingleton(interactObject, typeof(IInteractObject));
            }
            containerBuilder.AddSingleton(typeof(InteractObjectService), typeof(IInteractObjectService));
        }
    }
}