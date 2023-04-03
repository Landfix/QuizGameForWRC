using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "QuizConfigs",menuName = "Configs/QuizConfigs")]
    public class ThemeConfig : ScriptableObject
    {
        [SerializeField] private ThemeType _themeType;
        [SerializeField] private QuizConfig[] _quizConfigs;

        public ThemeType ThemeType => _themeType;
        public QuizConfig[] QuizConfigs => _quizConfigs;
    }
}