using System;
using Game.Services.GameSceneObjectsProvider;
using Game.Services.InputService;
using Game.Views;
using GameLoop.Interfaces;
using Generator;
using UnityEngine;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 240)]
    public class PlayerLookController : IUpdatable, IDisposable
    {
        private readonly PlayerView _playerView;
        private readonly IInputService _inputService;
        private readonly IDisposable _disposable;
        
        public PlayerLookController(
            IGameSceneObjectsProvider gameSceneObjectsProvider, 
            IInputService inputService
        )
        {
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
            _inputService = inputService;
        }

        public void Update()
        {
            if (!_inputService.IsMove)
                return;
            
            RotatePlayer(_inputService.MoveDirection);
        }

        
        
        private void RotatePlayer(Vector2 inputDelta)
        {
            if (inputDelta.magnitude < 0.1f)
                return;
            
            var direction = new Vector3(inputDelta.x, 0, inputDelta.y);
            var targetRotation = Quaternion.LookRotation(direction);
            
            _playerView.transform.rotation = targetRotation;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}