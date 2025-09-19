using UnityEngine;

namespace Utils.LayersUtil
{
    public class LayerMasks
    {
		private static readonly Mask DefaultMask = new Mask(Layers.Default, Layers.InteractObject);
		private static readonly Mask MouseMask = new Mask(Layers.InteractObject, Layers.Ground);
		private static readonly Mask PlayerMask = new Mask(Layers.Player);
		
		public static int Default => DefaultMask.Value;
		public static int Mouse => MouseMask.Value;
		public static int Player => PlayerMask.Value;

		private class Mask
		{
			private readonly string[] _layerNames;

			private int? _value;

			public Mask(params string[] layerNames)
			{
				_layerNames = layerNames;
			}

			public int Value
			{
				get
				{
					_value ??= LayerMask.GetMask(_layerNames);
					
					return _value.Value;
				}
			}
		}
    }
}