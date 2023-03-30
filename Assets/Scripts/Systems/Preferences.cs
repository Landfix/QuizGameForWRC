using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    [Serializable]
    public class Preferences
    {
        const string PreferencesKey = "preferences";

        bool _isInitialized = false;

        public int MaxNumberOfLevels { get; private set; }

        public void Init()
        {
            if (_isInitialized) return;

            string prefsString = PlayerPrefs.GetString(PreferencesKey, null);

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
        }
    }
}