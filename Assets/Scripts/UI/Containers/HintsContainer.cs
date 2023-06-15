using System;
using Systems;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Containers
{
    public enum RewardedKeyType
    {
        HideLetters,
        OpenLetter
    }

    public class HintsContainer : MonoBehaviour
    {
        private const string HideLettersKey = "HideLetters";
        private const string OpenLetterKey = "OpenLetter";
        
        [SerializeField] private Button _openLetterBtn;
        [SerializeField] private Button _hideLettersBtn;

        private AlphabeticButtonContainer _alphabeticButtonContainer;
        private GameSystemHandlers _systemHandlers;
        private Preferences _cachedPreferences;
        private string _answer;

        public void Initialize(GameSystemHandlers systemHandlers, AlphabeticButtonContainer alphabeticButtonContainer)
        {
            _systemHandlers = systemHandlers;
            _alphabeticButtonContainer = alphabeticButtonContainer;
            _cachedPreferences = GlobalManager.I.Preferences;
            _openLetterBtn.onClick.AddListener(OnClickOpenLetter);
            _hideLettersBtn.onClick.AddListener(OnClickHideLetters);
            _systemHandlers.SelectedContent += SelectedContent;
            
            GamePush.GP_Ads.OnRewardedStart += OnRewardedStart;
            GamePush.GP_Ads.OnRewardedReward += OnRewardedReward;
        }
        
        private void OnRewardedStart() => 
            _cachedPreferences.SetSoundPlayback(-1,true);

        private void OnRewardedReward(string key)
        {
            var keyType = Enum.Parse<RewardedKeyType>(key);
            _cachedPreferences.SetSoundPlayback(1,true);
            switch (keyType)
            {
                case RewardedKeyType.HideLetters:
                    _alphabeticButtonContainer.HideLetterButtons(_answer.ToCharArray());
                    break;
                case RewardedKeyType.OpenLetter:
                    _systemHandlers.LetterOpeningSystem.OpenRandomLetter(_alphabeticButtonContainer);
                    break;
            }
        }

        private void SelectedContent(ContentConfig config) => _answer = config.Answer;

        private void OnClickHideLetters() => 
            ShowRewarded(HideLettersKey);
        
        private void OnClickOpenLetter() => 
            ShowRewarded(OpenLetterKey);

        private void ShowRewarded(string key)
        {
            if(GamePush.GP_Ads.IsRewardedAvailable()) 
                GamePush.GP_Ads.ShowRewarded(key);
        }

        private void OnDestroy()
        {
            _openLetterBtn.onClick.RemoveListener(OnClickOpenLetter);
            _hideLettersBtn.onClick.RemoveListener(OnClickHideLetters);
            _systemHandlers.SelectedContent -= SelectedContent;
            GamePush.GP_Ads.OnRewardedStart -= OnRewardedStart;
            GamePush.GP_Ads.OnRewardedReward -= OnRewardedReward;
        }
    }
}