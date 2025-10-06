using Game.Services.ItemStorageService;

namespace Data.ItemsData
{
    public interface IItemCraftTimerData
    {
        float GetItemCraftTime(EItemType itemType);
    }
}