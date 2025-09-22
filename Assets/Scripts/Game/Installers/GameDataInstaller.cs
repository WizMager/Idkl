using Data.ItemsData;
using Data.ItemsData.Impl;
using Data.PlayerData;
using Data.PlayerData.Impl;
using Reflex.Core;
using UnityEngine;

namespace Game.Installers
{
    public class GameDataInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private ItemData _itemData;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddSingleton(_playerData, typeof(IPlayerData));
            containerBuilder.AddSingleton(_itemData, typeof(IItemData));
        }
    }
}