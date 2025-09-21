using R3;
using Ui.UiCore;

namespace Ui.WindowChanger.Impl
{
    public class UiWindowChanger : IUiWindowChanger
    {
        private readonly ReactiveCommand<EWindowName> _openWindowCommand = new ();
        private readonly ReactiveCommand<EWindowName> _openPopupWindowCommand = new ();
        private readonly ReactiveCommand<Unit> _closePopupWindowCommand = new ();
        
        public Observable<EWindowName> OpenedWindow => _openWindowCommand;
        public Observable<EWindowName> OpenedPopupWindow => _openPopupWindowCommand;
        public Observable<Unit> ClosedPopupWindow => _closePopupWindowCommand;
        
        public void OpenWindow(EWindowName windowName)
        {
            _openWindowCommand.Execute(windowName);
        }

        public void OpenPopupWindow(EWindowName windowName)
        {
            _openPopupWindowCommand.Execute(windowName);
        }

        public void ClosePopupWindow()
        {
            _closePopupWindowCommand.Execute(Unit.Default);
        }
    }
}