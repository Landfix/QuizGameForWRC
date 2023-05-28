using Systems;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TrophyElement : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private SpriteRenderer _model;
        [SerializeField] private Sprite _turnOffTrophy;
        [SerializeField] private Sprite _turnOnTrophy;

        [Header("Other components")] 
        [SerializeField] private TextMeshProUGUI _numberOfTrophyText;
        [SerializeField,Range(50,300)] private int _maxNumberOfTrophy;
        
        public void Initialize(Preferences preferences)
        {
            _numberOfTrophyText.text = $"{preferences.points}/{_maxNumberOfTrophy}";
            _model.sprite = CheckTrophy(preferences) ? _turnOnTrophy : _turnOffTrophy;
        }

        private bool CheckTrophy(Preferences preferences) => 
            preferences.points >= _maxNumberOfTrophy;
    }
}