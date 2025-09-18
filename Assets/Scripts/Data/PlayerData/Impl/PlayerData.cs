using UnityEngine;

namespace Data.PlayerData.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerData), fileName = nameof(PlayerData))]
    public class PlayerData : ScriptableObject, IPlayerData
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}