using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services.ItemStorageService.Impl
{
    public class ItemStorageService : IItemStorageService
    {
        private readonly Dictionary<EItemType, Item> _itemsStorage = new();

        public ItemStorageService()
        {
            foreach (EItemType itemType in Enum.GetValues(typeof(EItemType)))
            {
                _itemsStorage.Add(itemType, new Item
                {
                    ItemType = itemType,
                    Count = 0
                });
            }
        }

        public void AddItem(EItemType itemType, int count = 1)
        {
            _itemsStorage[itemType].Count += count;
            Debug.Log(_itemsStorage[itemType].Count);
        }

        public void RemoveItem(EItemType itemType, int count = 1)
        {
            if(_itemsStorage[itemType].Count <= 0)
                return;
            
            _itemsStorage[itemType].Count -= count;
        }
    }
}