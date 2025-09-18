namespace UiCore
{
    public abstract class AWindowController<TView> : IWindowController where TView : AWindowView
    {
        protected TView View { get; private set; }

        protected AWindowController(TView view)
        {
            View = view;
        }
        
        public void Activate()
        {
            View.gameObject.SetActive(true);
            
            OnShow();
        }

        public void Deactivate()
        {
            View.gameObject.SetActive(false);
            
            OnHide();
        }
        
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
    }
}