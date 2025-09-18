using UiCore;
using UnityEngine;

namespace Game.Ui.GameHudWindow
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