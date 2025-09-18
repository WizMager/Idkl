using Game.Services.InteractObjectService;
using R3;

namespace Game.Views.Interfaces
{
    public interface IInteractObject
    {
        Observable<InteractObjectData> OnMouseOver { get; }
        
        void MouseOver();
    }
}