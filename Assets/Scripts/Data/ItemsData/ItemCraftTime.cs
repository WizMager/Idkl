using System;
using Game.Services.ItemStorageService;

namespace Data.ItemsData
{
    [Serializable]
    public struct ItemCraftTime
    {
        public EItemType ItemType;
        public float CraftTime;
    }
}