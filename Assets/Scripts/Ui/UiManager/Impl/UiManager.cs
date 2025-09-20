using System.Collections.Generic;
using Ui.UiCore;

namespace Ui.UiManager.Impl
{
    public class UiManager : IUiManager
    {
        private readonly Dictionary<EWindowName, AWindow> _windows = new();
        private EWindowName _activeWindow = EWindowName.None;
        private EWindowName _popupWindow = EWindowName.None;
        
        public UiManager(IEnumerable<AWindow> windows)
        {
            foreach (var window in windows)
            {
                window.AddControllers();
                window.Activation(false);
                _windows.TryAdd(window.WindowName, window);
            }
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
    }
}