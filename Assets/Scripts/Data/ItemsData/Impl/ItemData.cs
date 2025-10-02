using System;
using System.Collections.Generic;
using Game.Services.InteractObjectService;
using Game.Services.ItemStorageService;
using UnityEngine;

namespace Data.ItemsData.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ItemData), fileName = nameof(ItemData))]
    public class ItemData : ScriptableObject, IItemData
    {
        [SerializeField] private List<ObjectItemPair> _defaultInteractObjectItems;
        [SerializeField] private List<ItemTypeSpritePair> _itemTypeSpritePairs;

        [field: SerializeField] public GameObject CraftItem { get; private set; }
        public IReadOnlyList<ObjectItemPair> GetDefaultItems => _defaultInteractObjectItems;

        public EItemType GetDefaultItem(EInteractObject interactObject)
        {
            foreach (var defaultInteractObjectItem in _defaultInteractObjectItems)
            {
                if (defaultInteractObjectItem.InteractObject != interactObject)
                    continue;

                return defaultInteractObjectItem.ItemType;
            }
            
            throw new Exception($"[{nameof(ItemData)}]: Default item not found for interact object {interactObject}");
        }
        
        public Sprite GetItemIcon(EItemType itemType)
        {
            foreach (var itemTypeSpritePair in _itemTypeSpritePairs)
            {
                if (itemTypeSpritePair.ItemType != itemType)
                    continue;
                
                return itemTypeSpritePair.Sprite;
            }
            
            throw new Exception($"[{nameof(ItemData)}]: Item icon not found for item type - {itemType}");
        }
    }
}