using Ui.UiCore;
using UnityEngine;

namespace Ui.Realization.GameHudWindow
{
    public class GameHudView : AWindowView
    {
        [SerializeField] private Transform _crossfireTransform;

        public void SetCrossfirePosition(Vector2 position)
        {
            _crossfireTransform.position = position;
        }
    }
}