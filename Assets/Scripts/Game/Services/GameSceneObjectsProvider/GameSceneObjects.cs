using Game.Views;
using Game.Views.Abstractions;
using UnityEngine;

namespace Game.Services.GameSceneObjectsProvider
{
    public class GameSceneObjects : MonoBehaviour
    {
        [field: SerializeField] public PlayerView PlayerView { get; private set; }
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public AInteractObject[] InteractObjects { get; private set; }
    }
}