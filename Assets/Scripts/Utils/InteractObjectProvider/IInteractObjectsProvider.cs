using Game.Views.Interfaces;

namespace Utils.InteractObjectProvider
{
    public interface IInteractObjectsProvider
    {
        IInteractObject[] GetInteractObjects();
    }
}