using System.Collections.Generic;
using Game.Services.InteractObjectService;
using Game.Services.ItemStorageService;

namespace Data.ItemsData
{
    public interface IItemData
    {
        IReadOnlyList<ObjectItemPair> GetDefaultItems { get; }
        
        EItemType GetDefaultItem(EInteractObject interactObject);
    }
}