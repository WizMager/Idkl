using Game.Services.InteractObjectService;
using Game.Services.UiManager;
using Game.Ui.InteractObjectStatusWindow;
using Game.Views.Interfaces;
using R3;
using R3.Triggers;
using Reflex.Attributes;
using UiCore;
using UnityEngine;
using Utils.LayersUtil;

namespace Game.Views.Abstractions
{
    public abstract class AInteractObject : MonoBehaviour, IInteractObject
    {
        public Observable<InteractObjectData> OnPlayerEntered  => _onPlayerEnteredCommand;
        
        [SerializeField] private EInteractObject _interactObjectType;
        [SerializeField] private Collider _interactCollider;
        
        private readonly ReactiveCommand<InteractObjectData> _onPlayerEnteredCommand = new ();

        [Inject] private IUiManager _uiManager;

        private void Start()
        {
            _interactCollider.OnTriggerEnterAsObservable().Subscribe(OnObjectEnter).AddTo(this);
        }

        private void OnObjectEnter(Collider other)
        {
            if (other.IsOnLayer(Layers.PlayerLayer))
                return;
            _uiManager.OpenWindow(EWindowName.InteractObjectStatus);
            _onPlayerEnteredCommand.Execute(new InteractObjectData(_interactObjectType));
        }
    }
}