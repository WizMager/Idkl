namespace Game.Services.ItemStorageService
{
    public interface IItemStorageService
    {
        void AddItem(EItemType itemType, int count = 1);
        void RemoveItem(EItemType itemType, int count = 1);
    }
}