using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        bool IsMove { get; }
        Vector2 MoveDirection { get; }
    }
}