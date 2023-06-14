using Systems;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TrophyContainer : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI _numberOfTrophyText;
        [SerializeField] private TrophyElement _trophyElement;
        [Header("Parameters")]
        [SerializeField,Range(100,5000)] private int _maxNumberOfTrophy;

        public void Initialize(Preferences preferences)
        {
            _numberOfTrophyText.text = $"{preferences.points}/{_maxNumberOfTrophy}";
            _trophyElement.Initialize(preferences, _maxNumberOfTrophy);
        }
    }
}