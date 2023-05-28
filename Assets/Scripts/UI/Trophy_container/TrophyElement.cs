using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TrophyElement : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Image _model;
        [SerializeField] private Sprite _lockTrophy;
        [SerializeField] private Sprite _unlockTrophy;
        
        public void Initialize(Preferences preferences, int maxNumberOfTrophy) => 
            _model.sprite = CheckTrophy(preferences, maxNumberOfTrophy) ? _unlockTrophy : _lockTrophy;

        private bool CheckTrophy(Preferences preferences, int maxNumberOfTrophy) => 
            preferences.points >= maxNumberOfTrophy;
    }
}