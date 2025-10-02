using System.Collections.Generic;
using Game.Services.InteractObjectService;
using Game.Services.ItemStorageService;
using UnityEngine;

namespace Data.ItemsData
{
    public interface IItemData
    {
        IReadOnlyList<ObjectItemPair> GetDefaultItems { get; }
        GameObject CraftItem { get; }
        
        EItemType GetDefaultItem(EInteractObject interactObject);
        Sprite GetItemIcon(EItemType itemType);
    }
}