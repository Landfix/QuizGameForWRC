using System;
using UnityEngine;

namespace Systems
{
    [Serializable]
    public class Preferences
    {
        public int points = 10;

        public int soundPlayback = 1;
        public int adsSoundPlayback = -1;
        public int rewardReplay = 1;

        const string PreferencesKey = "preferences";

        bool _isInitialized = false;

        public event Action<bool> TurnedOffSoundToAds;
        public event Action<bool> SwitchedSoundByButton;

        public void Init()
        {
            if (_isInitialized) return;

            //string prefsString = PlayerPrefs.GetString(PreferencesKey, null);
            string prefsString = GamePush.GP_Player.GetString(PreferencesKey);

            if (string.IsNullOrEmpty(prefsString))
            {
                SetDefaultPrefs();
            }
            else
            {
                try
                {
                    Copy(JsonUtility.FromJson<Preferences>(prefsString));
                }
                catch
                {
                    Debug.LogError($"Invalid preferences string format: {prefsString}");
                    PlayerPrefs.DeleteKey(PreferencesKey);
                    SetDefaultPrefs();
                }
            }

            _isInitialized = true;
        }

        public void Copy(Preferences other)
        {
            points = other.points;
            soundPlayback = other.soundPlayback;
            adsSoundPlayback = other.adsSoundPlayback;
            rewardReplay = other.rewardReplay;
        }

        public void SetDefaultPrefs()
        {
            Copy(new Preferences());
            SavePreferences();
        }

        public void SavePreferences()
        {
            string preferencesString = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PreferencesKey, preferencesString);
            
            // todo recast
            GamePush.GP_Player.Set(PreferencesKey,preferencesString);
            GamePush.GP_Player.Sync();
        }

        public void AddPoints(int value)
        {
            points += value;
            SavePreferences();
        }
        
        public void RemovePoints(int value)
        {
            if (points >= value) 
                points -= value;
            
            SavePreferences();
        }
        
        public void SetSoundPlayback(int value, bool isAds = false)
        {
            if (isAds)
            {
                adsSoundPlayback = value;
                TurnedOffSoundToAds?.Invoke(adsSoundPlayback == 1);
            }
            else
            {
                soundPlayback = value;
                SwitchedSoundByButton?.Invoke(soundPlayback == 1);
            }

            SavePreferences();
        }

        public void SetRewardReplay(int value)
        {
            rewardReplay = value;
            SavePreferences();
        }
    }
}