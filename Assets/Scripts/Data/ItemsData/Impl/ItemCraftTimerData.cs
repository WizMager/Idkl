using System.Collections.Generic;
using Game.Services.ItemStorageService;
using UnityEngine;

namespace Data.ItemsData.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ItemCraftTimerData), fileName = nameof(ItemCraftTimerData))]
    public class ItemCraftTimerData : ScriptableObject, IItemCraftTimerData
    {
        [SerializeField] private List<ItemCraftTime> _itemCraftTimes;
        
        private readonly Dictionary<EItemType, float> _itemCraftTimesDick = new ();

        public float GetItemCraftTime(EItemType itemType)
        {
            if (_itemCraftTimesDick.TryGetValue(itemType, out var value))
            {
                return value;
            }
            
            Debug.LogError($"[{nameof(ItemCraftTimerData)}]: There is no key {itemType} in dictionary.");

            return int.MaxValue;
        }
        
        private void OnValidate()
        {
            _itemCraftTimesDick.Clear();

            foreach (var itemCraftTime in _itemCraftTimes)
            {
                if (_itemCraftTimesDick.ContainsKey(itemCraftTime.ItemType))
                {
                    Debug.LogError($"[{nameof(ItemCraftTimerData)}]: There is two same EItemType - {itemCraftTime.ItemType} in list. Check duplicate in list.");
                    continue;
                }
                
                _itemCraftTimesDick.Add(itemCraftTime.ItemType, itemCraftTime.CraftTime);
            }
        }
    }
}