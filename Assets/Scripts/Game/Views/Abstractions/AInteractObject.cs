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
        [SerializeField] private EInteractObject _interactObjectType;
        [SerializeField] private Collider _interactCollider;
        [SerializeField] private float _baseTimeForAction;
        
        private readonly ReactiveCommand<InteractObjectData> _onPlayerEnteredCommand = new ();
        private readonly ReactiveCommand<Unit> _onPlayerExitedCommand = new ();

        public Observable<InteractObjectData> OnPlayerEntered  => _onPlayerEnteredCommand;
        public Observable<Unit> OnPlayerExited => _onPlayerExitedCommand;
        
        private void Start()
        {
            _interactCollider.OnTriggerEnterAsObservable().Subscribe(OnPlayerEnter).AddTo(this);
            _interactCollider.OnTriggerExitAsObservable().Subscribe(OnPlayerExit).AddTo(this);
        }

        private void OnPlayerEnter(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            
            _onPlayerEnteredCommand.Execute(new InteractObjectData(_interactObjectType, _baseTimeForAction));
        }
        
        private void OnPlayerExit(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            
            _onPlayerExitedCommand.Execute(Unit.Default);
        }
    }
}