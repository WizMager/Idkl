using System;
using System.Collections.Generic;
using Game.Services.InteractObjectService;
using Game.Services.ItemStorageService;

namespace Utils.ItemTypeHelper
{
    public static class ItemTypeMapper
    {
        private static readonly Dictionary<EItemType, EInteractObject> _itemsMap = new();
        private static readonly Dictionary<EInteractObject, EItemType[]> _itemsInInteractObject = new();
    
        static ItemTypeMapper()
        {
            AddRange(EInteractObject.Forest, 0, 49);
            AddRange(EInteractObject.Lake, 50, 99);
        }
    
        private static void AddRange(EInteractObject interactObject, int min, int max)
        {
            var items = new List<EItemType>();
            foreach (EItemType itemType in Enum.GetValues(typeof(EItemType)))
            {
                var value = (int)itemType;
                if (value < min || value > max) 
                    continue;
                
                if (_itemsMap.ContainsKey(itemType))
                {
                    throw new InvalidOperationException($"[{nameof(ItemTypeMapper)}]:EItemType {itemType} already mapped to {_itemsMap[itemType]}");
                }
                
                _itemsMap[itemType] = interactObject;
                items.Add(itemType);
            }
            
            _itemsInInteractObject.Add(interactObject, items.ToArray());
        }
    
        public static EInteractObject GetInteractObject(EItemType itemType) => _itemsMap[itemType];
        
        public static EItemType[] GetItemsByInteractObject(EInteractObject interactObject) => _itemsInInteractObject[interactObject];
    }
}