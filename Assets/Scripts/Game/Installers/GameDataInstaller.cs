using Data.PlayerData;
using Data.PlayerData.Impl;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameDataInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private PlayerData _playerData;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_playerData, typeof(IPlayerData));
        }
    }
}