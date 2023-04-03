using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "ThemeConfigs",menuName = "Configs/ThemeConfigs")]
    public class ThemeConfigs : ScriptableObject
    {
        [SerializeField] private ThemeConfig[] _themeConfig;

        public ThemeConfig[] ThemeConfig => _themeConfig;
    }
}