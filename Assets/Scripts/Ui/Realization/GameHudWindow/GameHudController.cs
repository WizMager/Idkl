using System;
using Game.Services.InputService;
using Ui.UiCore;
using UnityEngine;

namespace Ui.Realization.GameHudWindow
{
    public class GameHudController : AWindowController<GameHudView>, IDisposable
    {
        private readonly IDisposable _disposable;
        
        public GameHudController(
            GameHudView view,
            IInputService inputService
        ) : base(view)
        {
            //_disposable = inputService.MousePosition.Subscribe(OnCrossfirePositionChange);
        }
        
        private void OnCrossfirePositionChange(Vector2 lookPosition)
        {
            View.SetCrossfirePosition(lookPosition);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}