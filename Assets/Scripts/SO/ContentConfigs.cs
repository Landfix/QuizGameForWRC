using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ContentConfigs",menuName = "Configs/ContentConfigs",order = 1)]
    public class ContentConfigs : ScriptableObject
    {
        [SerializeField] private ContentConfig[] _contents;
        [SerializeField, Range(3, 10)] private int _numberOfAttempts = 4;

        public ContentConfig[] Contents => _contents;
        public int NumberOfAttempts => _numberOfAttempts;
    }
}