using System;
using Game.Services.InteractObjectService;
using Game.Services.ItemStorageService;

namespace Data.ItemsData
{
    [Serializable]
    public struct ObjectItemPair
    {
        public EInteractObject InteractObject;
        public EItemType ItemType;
    }
}