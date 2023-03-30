using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "QuizConfigs",menuName = "Configs/QuizConfigs")]
    public class QuizConfigs : ScriptableObject
    {
        [SerializeField] private QuizConfig[] _quizConfig;

        public QuizConfig[] QuizConfig => _quizConfig;
    }
}