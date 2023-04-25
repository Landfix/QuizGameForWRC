using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Content config",menuName = "Configs/Content",order = 1)]
    public class ContentConfig : ScriptableObject
    {
        [Header("Content")]
        [SerializeField,TextArea] private string _content;

        [Header("Parameters Game")]
        [SerializeField,Range(3,10)] private int _wordLength;

        [SerializeField, Range(3, 10)] private int _numberOfAttempts;
        
        public string Content => _content;
        public int WordLength => _wordLength;
        public int NumberOfAttempts => _numberOfAttempts;
        
    }
}