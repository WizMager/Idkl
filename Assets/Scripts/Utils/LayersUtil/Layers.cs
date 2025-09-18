using UnityEngine;

namespace Utils.LayersUtil
{
    public class Layers
    {
        public const string Default = "Default";
        public const string InteractObject = "InteractObject";
        public const string Ground = "Ground";
        
        private static readonly Layer _defaultLayer = new Layer(Default);
        private static readonly Layer _interactObjectLayer = new Layer(InteractObject);
        private static readonly Layer _groundLayer = new Layer(Ground);
        
        public static int DefaultLayer => _defaultLayer.Id;
        public static int InteractObjectLayer => _interactObjectLayer.Id;
        public static int GroundLayer => _groundLayer.Id;

        private class Layer
        {
            private readonly string _name;

            private int? _id;

            public int Id
            {
                get
                {
                    if (!_id.HasValue)
                        _id = LayerMask.NameToLayer(_name);
                    return _id.Value;
                }
            }

            public Layer(string name)
            {
                _name = name;
            }
        }
    }
}