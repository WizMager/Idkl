using Game.Services.ItemStorageService;

namespace Game.Services.InteractObjectService
{
    public interface IInteractObjectService
    {
        InteractObjectData GetCurrentInteractObjectData();
        void AddResourceFromObject();
    }
}