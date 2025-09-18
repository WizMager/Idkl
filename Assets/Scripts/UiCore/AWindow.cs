using System.Collections.Generic;
using Reflex.Core;

namespace UiCore
{
    public abstract class AWindow
    {
        private readonly List<IWindowController> _controllers = new();
        private readonly Container _containerBuilder;
        
        public abstract EWindowName WindowName { get; }

        protected AWindow(Container containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public abstract void AddControllers();

        protected void AddController<TController>()
            where TController : IWindowController
        {
            var controller = _containerBuilder.Resolve<TController>();
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