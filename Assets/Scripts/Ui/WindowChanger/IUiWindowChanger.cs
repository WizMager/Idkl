using R3;
using Ui.UiCore;

namespace Ui.WindowChanger
{
    public interface IUiWindowChanger
    {
        Observable<EWindowName> OpenedWindow { get; }
        Observable<EWindowName> OpenedPopupWindow { get; }
        Observable<Unit> ClosedPopupWindow { get; }
        
        void OpenWindow(EWindowName windowName);
        void OpenPopupWindow(EWindowName windowName);
        void ClosePopupWindow();
    }
}