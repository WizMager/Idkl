using System;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Services.InputService.Impl
{
    public class InputService : IInputService, IDisposable
    {
        private readonly InputSystem_Actions _actions = new();
        
        public bool IsMove { get; private set; }
        public ReactiveProperty<bool> IsMoveProperty { get; } = new();
        public Vector2 MoveDirection { get; private set; }

        public InputService()
        {
            _actions.Enable();
            
            _actions.Player.Look.performed += OnLookPerformed;
            _actions.Player.Look.canceled += OnLookCanceled;
        }
        
        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            if (!IsMove)
            {
                IsMove = true;
                IsMoveProperty.Value = true;
            }
            
            MoveDirection = context.ReadValue<Vector2>();
        }
        
        private void OnLookCanceled(InputAction.CallbackContext context)
        {
            if (!IsMove)
                return;
            
            IsMoveProperty.Value = false;
            IsMove = false;
        }
        
        public void Dispose()
        {
            _actions.Player.Look.performed -= OnLookPerformed;
            _actions.Player.Look.canceled -= OnLookCanceled;
            
            _actions.Disable();
            _actions.Dispose();
        }
    }
}