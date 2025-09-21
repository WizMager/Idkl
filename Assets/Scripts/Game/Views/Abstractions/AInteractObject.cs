using Game.Services.InteractObjectService;
using Game.Views.Interfaces;
using R3;
using R3.Triggers;
using Reflex.Attributes;
using Ui.UiCore;
using Ui.UiManager;
using UnityEngine;
using Utils.LayersUtil;

namespace Game.Views.Abstractions
{
    public abstract class AInteractObject : MonoBehaviour, IInteractObject
    {
        public Observable<InteractObjectData> OnPlayerEntered  => _onPlayerEnteredCommand;
        public Observable<Unit> OnPlayerExited => _onPlayerExitedCommand;

        [SerializeField] private EInteractObject _interactObjectType;
        [SerializeField] private Collider _interactCollider;
        
        private readonly ReactiveCommand<InteractObjectData> _onPlayerEnteredCommand = new ();
        private readonly ReactiveCommand<Unit> _onPlayerExitedCommand = new ();

        [Inject] private IUiManager _uiManager;

        private void Start()
        {
            _interactCollider.OnTriggerEnterAsObservable().Subscribe(OnPlayerEnter).AddTo(this);
            _interactCollider.OnTriggerExitAsObservable().Subscribe(OnPlayerExit).AddTo(this);
        }

        private void OnPlayerEnter(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            
            _onPlayerEnteredCommand.Execute(new InteractObjectData(_interactObjectType));
        }
        
        private void OnPlayerExit(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            
            _onPlayerExitedCommand.Execute(Unit.Default);
        }
    }
}