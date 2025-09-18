using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Services.InputService.Impl
{
    public class InputService : IInputService, IDisposable
    {
        private readonly InputSystem_Actions _actions = new();
        
        public bool IsMove { get; private set; }
        public Vector2 MoveDirection { get; private set; }

        public InputService()
        {
            _actions.Enable();
            
            _actions.Player.Look.performed += OnLookPerformed;
            _actions.Player.Touch.performed += OnTouchPerformed;
            _actions.Player.Touch.canceled += OnTouchEnd;
        }

        private void OnTouchEnd(InputAction.CallbackContext obj)
        {
            if (!IsMove)
                return;
            
            IsMove = false;
        }

        private void OnTouchPerformed(InputAction.CallbackContext obj)
        {
            if (IsMove)
                return;
            
            IsMove = true;
        }
        
        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }
        
        public void Dispose()
        {
            _actions.Player.Look.performed -= OnLookPerformed;
            _actions.Player.Touch.performed -= OnTouchPerformed;
            _actions.Player.Touch.canceled -= OnTouchEnd;
            
            _actions.Disable();
            _actions.Dispose();
        }
    }
}