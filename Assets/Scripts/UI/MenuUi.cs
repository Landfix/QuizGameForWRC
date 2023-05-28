using System;
using Systems;
using Sounds_container;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MenuUi : MonoBehaviour
    {
        [SerializeField] private SoundEffect _soundEffect;

        [Header("Components")]
        [SerializeField] private TrophyElement _trophyElement;
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private Button _playBtn;

        private Preferences _preferences;
        
        private void Start()
        {
            _preferences = GlobalManager.I.Preferences;
            _playBtn.onClick.AddListener(OnClickPlay);
            _trophyElement.Initialize(_preferences);
            _soundButton.Initialize(_preferences,_soundEffect);
            _soundButton.ChangedSound += GlobalManager.I.MusicEffect.IsPlaybackMusic;
        }

        private void OnClickPlay()
        {
            _soundEffect.PlayClip();
            _playBtn.onClick.RemoveListener(OnClickPlay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void OnDestroy()
        {
            _playBtn.onClick.RemoveListener(OnClickPlay);
            _soundButton.ChangedSound -= GlobalManager.I.MusicEffect.IsPlaybackMusic;
        }
    }
}