using Game.Services.GameSceneObjectsProvider;
using GameLoop.Interfaces;
using Generator;
using UnityEngine;

namespace Game.Controllers
{
    [Install(EExecutionPriority.Normal, 500)]
    public class PlayerCameraController : IStartable, ILateUpdatable
    {
        private readonly Transform _playerTransform;
        private readonly Transform _cameraTransform;
        
        public PlayerCameraController(IGameSceneObjectsProvider gameSceneObjectsProvider)
        {
            _cameraTransform = gameSceneObjectsProvider.GameSceneObjects.Camera.transform;
            _playerTransform = gameSceneObjectsProvider.GameSceneObjects.PlayerView.transform;
        }
        
        public void Start()
        {
            var cameraPosition  = _playerTransform.position;
            cameraPosition.y = 30;
            
            _cameraTransform.position = cameraPosition;
        }

        public void LateUpdate()
        {
            if (!Mathf.Approximately(_cameraTransform.position.x, _playerTransform.position.x) || !Mathf.Approximately(_cameraTransform.position.z, _playerTransform.position.z))
            {
                _cameraTransform.position = new Vector3(_playerTransform.position.x, 30, _playerTransform.position.z);
            }
        }
    }
}