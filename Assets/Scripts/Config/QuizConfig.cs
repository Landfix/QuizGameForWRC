using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "QuizConfig",menuName = "Configs/QuizConfig")]
    public class QuizConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _question;
        [SerializeField] private string _correctAnswer;
        [Header("Answers")] 
        [SerializeField] private string[] _answers = new string[4];

        public Sprite Icon => _icon;
        public string Question => _question;
        public string CorrectAnswer => _correctAnswer;
        public string[] Answers => _answers;
    }
}