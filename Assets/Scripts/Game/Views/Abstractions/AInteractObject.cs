using Game.Services.InteractObjectService;
using Game.Views.Interfaces;
using R3;
using R3.Triggers;
using UnityEngine;
using Utils.LayersUtil;

namespace Game.Views.Abstractions
{
    public abstract class AInteractObject : MonoBehaviour, IInteractObject
    {
        public Observable<InteractObjectData> OnMouseOver  => _onMouseOverCommand;
        public Observable<InteractObjectData> OnPlayerEntered  => _onPlayerEnteredCommand;
        
        [SerializeField] private EInteractObject _interactObjectType;
        [SerializeField] private Collider _interactCollider;
        
        private readonly ReactiveCommand<InteractObjectData> _onMouseOverCommand = new ();
        private readonly ReactiveCommand<InteractObjectData> _onPlayerEnteredCommand = new ();

        private void Start()
        {
            _interactCollider.OnTriggerEnterAsObservable().Subscribe(OnObjectEnter).AddTo(this);
        }

        private void OnObjectEnter(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            
            Debug.Log("check");
        }
        
        public void MouseOver()
        {
            _onMouseOverCommand.Execute(new InteractObjectData(_interactObjectType));
        }
    }
}