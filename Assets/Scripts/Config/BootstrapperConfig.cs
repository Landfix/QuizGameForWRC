using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "BootstrapperConfig",menuName = "Configs/BootstrapperConfig")]
    public class BootstrapperConfig : ScriptableObject
    {
        [SerializeField,Range(5f,25f)] private float _gameDuration = 15f;

        public float GameDuration => _gameDuration;
    }
}