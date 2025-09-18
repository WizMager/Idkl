using System.Collections.Generic;
using GameLoop.Interfaces;
using Reflex.Attributes;
using UnityEngine;

namespace GameLoop
{
    public class GameLoopHandler : MonoBehaviour
    {
        [Inject] private IEnumerable<IController> _controllers;
        
        private readonly List<IStartable> _startables = new ();
        private readonly List<IUpdatable> _updatables = new();
        private readonly List<IFixedUpdatable> _fixedUpdatables = new();
        private readonly List<ILateUpdatable> _lateUpdatables = new();

        private void Awake()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IStartable startable)
                {
                    _startables.Add(startable);
                }
                
                if (controller is IUpdatable updatable)
                {
                    _updatables.Add(updatable);
                }
                
                if (controller is IFixedUpdatable fixedUpdatable)
                {
                    _fixedUpdatables.Add(fixedUpdatable);
                }
                
                if (controller is ILateUpdatable lateUpdatable)
                {
                    _lateUpdatables.Add(lateUpdatable);
                }
            }
        }

        private void Start()
        {
            foreach (var startable in _startables)
            {
                startable.Start();
            }
        }
        
        private void Update()
        {
            
            foreach (var updatable in _updatables)
            {
                updatable.Update();
            }
        }
        
        private void FixedUpdate()
        {
            foreach (var fixedUpdatable in _fixedUpdatables)
            {
                fixedUpdatable.FixedUpdate();
            }
        }
        
        private void LateUpdate()
        {
            foreach (var lateUpdatable in _lateUpdatables)
            {
                lateUpdatable.LateUpdate();
            }
        }
    }
}