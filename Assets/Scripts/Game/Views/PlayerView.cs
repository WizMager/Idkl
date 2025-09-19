using UnityEngine;

namespace Game.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public Rigidbody Rigidbody => _rigidbody;
    }
}