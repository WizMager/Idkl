using Data.PlayerData;
using Game.Services.GameSceneObjectsProvider;
using Game.Services.InputService;
using Game.Views;
using GameLoop.Interfaces;
using Generator;
using UnityEngine;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 250)]
    public class PlayerMovementController : IUpdatable
    {
        private readonly IInputService _inputService;
        private readonly PlayerView _playerView;
        private readonly IPlayerData _playerData;
        
        public PlayerMovementController(
            IInputService inputService,
            IGameSceneObjectsProvider gameSceneObjectsProvider, 
            IPlayerData playerData
        )
        {
            _inputService = inputService;
            _playerData = playerData;
            _playerView = gameSceneObjectsProvider.GameSceneObjects.PlayerView;
        }

        public void Update()
        {
            if (!_inputService.IsMove)
                return;
            
            _playerView.transform.position += _playerView.transform.forward * Time.deltaTime * _playerData.MoveSpeed;
        }
    }
}