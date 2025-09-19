using UnityEngine;

namespace Utils.LayersUtil
{
    public static class LayerMasksUtils
    {
        public static bool IsOnLayer(this Component component, int layerMask) 
            => layerMask == (layerMask | (1 << component.gameObject.layer));
    }
}