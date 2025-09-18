using Game.Services.InteractObjectService;
using Game.Views.Interfaces;
using R3;
using UnityEngine;

namespace Game.Views.Abstractions
{
    public abstract class AInteractObject : MonoBehaviour, IInteractObject
    {
        public Observable<InteractObjectData> OnMouseOver  => _onMouseOverCommand;
        
        [SerializeField] private EInteractObject _interactObjectType;
        
        private readonly ReactiveCommand<InteractObjectData> _onMouseOverCommand = new ();
        
        public void MouseOver()
        {
            _onMouseOverCommand.Execute(new InteractObjectData(_interactObjectType));
        }
    }
}