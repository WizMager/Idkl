using Ui.UiCore;

namespace Ui.UiManager
{
    public interface IUiManager
    {
        public void OpenWindow(EWindowName windowName);
        public void OpenPopupWindow(EWindowName windowName);
        void ClosePopupWindow();
        public void CloseWindows();
    }
}