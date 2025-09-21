using Game.Views.Interfaces;

namespace Utils.InteractObjectProvider
{
    public class InteractObjectsProvider : IInteractObjectsProvider
    {
        private readonly IInteractObject[] _interactObjects;

        public InteractObjectsProvider(IInteractObject[] interactObjects)
        {
            _interactObjects = interactObjects;
        }
        
        public IInteractObject[] GetInteractObjects()
        {
            return _interactObjects;
        }
    }
}