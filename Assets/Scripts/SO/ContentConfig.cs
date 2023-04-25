using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Content config",menuName = "Configs/Content",order = 1)]
    public class ContentConfig : ScriptableObject
    {
        [Header("Content")]
        [SerializeField,TextArea] private string _question;
        [SerializeField] private string _answer;

        public string Question => _question;
        public string Answer => _answer.ToUpper();
        
    }
}