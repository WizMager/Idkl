using Game.Services.ItemStorageService;
using Ui.Realization.InteractObjectStatusWindow;
using UnityEngine;

namespace Game.Services.InteractObjectService
{
    public interface IInteractObjectService
    {
        InteractObjectData GetCurrentInteractObjectData();
        void AddResourceFromObject();
        void ChangeCurrentCraftItem(EItemType itemType);
        EItemType GetCurrentItemFromObject();
    }
}