using System;
using Systems;
using Sounds_container;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [Header("Sprites")]
        [SerializeField] private Sprite _soundSprite;
        [SerializeField] private Sprite _withoutSoundSprite;

        private bool _isSoundPlayback;
        private SoundEffect _soundEffect;
        private Preferences _preferences;

        public event Action<bool> ChangedSound;
        
        public void Initialize(Preferences preferences, SoundEffect soundEffect)
        {
            _soundEffect = soundEffect;
            _preferences = preferences;
            _button.onClick.AddListener(OnClickSound);
            _isSoundPlayback = _preferences.soundPlayback == 1;
            _button.image.sprite = _isSoundPlayback ? _soundSprite : _withoutSoundSprite;
            _preferences.SwitchedSoundByButton += SwitchedSoundByButton;
        }

        private void SwitchedSoundByButton(bool isActivate)
        {
            if (isActivate)
            {
                _isSoundPlayback = true;
                _button.image.sprite = _soundSprite;
                ChangedSound?.Invoke(isActivate);
            }
            else
            {
                _isSoundPlayback = false;
                _button.image.sprite = _withoutSoundSprite;
                ChangedSound?.Invoke(isActivate);
            }
        }

        private void OnClickSound()
        {
            if(_isSoundPlayback)
                _soundEffect.PlayClip();
            
            _isSoundPlayback = !_isSoundPlayback;
            _button.image.sprite = _isSoundPlayback ? _soundSprite : _withoutSoundSprite;
            ChangedSound?.Invoke(_isSoundPlayback);
            _preferences.SetSoundPlayback(_isSoundPlayback ? 1 : -1);
        }
    }
}