using System;
using System.Collections.Generic;
using R3;
using Ui.UiCore;
using Ui.WindowChanger;

namespace Ui.UiManager.Impl
{
    public class UiManager : IUiManager, IDisposable
    {
        private readonly Dictionary<EWindowName, AWindow> _windows = new();
        private readonly CompositeDisposable _disposable = new();
        
        private EWindowName _activeWindow = EWindowName.None;
        private EWindowName _popupWindow = EWindowName.None;
        
        public UiManager(IEnumerable<AWindow> windows, IUiWindowChanger uiWindowChanger)
        {
            foreach (var window in windows)
            {
                window.AddControllers();
                window.Activation(false);
                _windows.TryAdd(window.WindowName, window);
            }
            
            _disposable.Add(uiWindowChanger.OpenedWindow.Subscribe(OpenWindow));
            _disposable.Add(uiWindowChanger.OpenedPopupWindow.Subscribe(OpenPopupWindow));
            _disposable.Add(uiWindowChanger.ClosedPopupWindow.Subscribe(_ => ClosePopupWindow()));
        }

        public void OpenWindow(EWindowName windowName)
        {
            if (_activeWindow != EWindowName.None)
            {
                _windows[_activeWindow].Activation(false);
            }
            
            _activeWindow = windowName;
            _windows[_activeWindow].Activation(true);
        }

        public void OpenPopupWindow(EWindowName windowName)
        {
            _popupWindow = windowName;
            _windows[_popupWindow].Activation(true);
        }
        
        public void ClosePopupWindow()
        {
            if (_popupWindow == EWindowName.None)
                return;
            
            _windows[_popupWindow].Activation(false);
        }

        public void CloseWindows()
        {
            foreach (var window in _windows)
            {
                window.Value.Activation(false);
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}