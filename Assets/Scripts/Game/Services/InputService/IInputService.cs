using R3;
using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        bool IsMove { get; }
        ReactiveProperty<bool> IsMoveProperty { get; }
        Vector2 MoveDirection { get; }
    }
}