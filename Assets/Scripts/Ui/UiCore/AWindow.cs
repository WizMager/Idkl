using System.Collections.Generic;
using Reflex.Core;

namespace Ui.UiCore
{
    public abstract class AWindow
    {
        private readonly List<IWindowController> _controllers = new();
        private readonly Container _container;
        
        public abstract EWindowName WindowName { get; }

        protected AWindow(Container container)
        {
            _container = container;
        }

        public abstract void AddControllers();

        protected void AddController<TController>()
            where TController : IWindowController
        {
            var controller = _container.Resolve<TController>();
            _controllers.Add(controller);
        }

        public void Activation(bool isActive)
        {
            if (isActive)
            {
                foreach (var controller in _controllers)
                {
                    controller.Activate();
                }
            }
            else
            {
                foreach (var controller in _controllers)
                {
                    controller.Deactivate();
                }
            }
        }
    }
}