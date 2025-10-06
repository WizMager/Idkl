using Game.Services.ItemStorageService;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Realization.InteractObjectStatusWindow
{
    public class CraftItem : MonoBehaviour
    {
        [SerializeField] private Image _craftItemImage;
        [SerializeField] private TMP_Text _craftItemName;
        
        private readonly ReactiveCommand<EItemType> _itemChooseCommand = new ();

        private EItemType _itemType;

        public Observable<EItemType> OnItemChoose => _itemChooseCommand;
        public EItemType ItemType => _itemType;
        
        public void Init(Sprite sprite, EItemType itemType, RectTransform parent)
        {
            _craftItemImage.sprite = sprite;
            _itemType = itemType;
            _craftItemName.text = itemType.ToString();
            ParentingTo(parent);
            transform.localScale = Vector3.one; //TODO: crutch, scale change when add GO in scroll view
            
            _craftItemImage.OnPointerClickAsObservable().Subscribe(_ => OnChoose()).AddTo(this);
        }

        public void Activate(RectTransform parent)
        {
            _craftItemImage.enabled = true;
            _craftItemName.enabled = true;
            ParentingTo(parent);
        }
        
        public void Deactivate(Transform parent)
        {
            transform.SetParent(parent);
            _craftItemImage.enabled = false;
            _craftItemName.enabled = false;
        }
        
        private void ParentingTo(RectTransform parent = null)
        {
            transform.SetParent(parent);
        }
        
        private void OnChoose()
        {
            _itemChooseCommand?.Execute(_itemType);
        }
    }
}