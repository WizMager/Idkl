using System;
using Game.Services.ItemStorageService;
using UnityEngine;

namespace Data.ItemsData
{
    [Serializable]
    public struct ItemTypeSpritePair
    {
        public EItemType ItemType;
        public Sprite Sprite;
    }
}