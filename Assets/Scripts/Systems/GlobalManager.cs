using Sounds_container;
using UnityEngine;
using Utils;

namespace Systems
{
    public class GlobalManager : SingletonMono<GlobalManager>
    {
        [SerializeField] private MusicEffect _musicEffect;
        
        private readonly Preferences _preferences = new Preferences();
        
        public Preferences Preferences => _preferences;
        public MusicEffect MusicEffect => _musicEffect;

        public override void Awake()
        {
            base.Awake();
            GamePush.GP_Player.OnReady += OnPlayerReady;
            GamePush.GP_Game.OnPause += OnPause;
            GamePush.GP_Game.OnResume += OnResume;
            
            // todo delete
            // _preferences.Init();
            // _musicEffect.Initialize(_preferences);
        }

        private void OnPlayerReady()
        {
            _preferences.Init();
            _musicEffect.Initialize(_preferences);
        }

        private void OnResume() => 
            _preferences.SetSoundPlayback(1, true);

        private void OnPause() => 
            _preferences.SetSoundPlayback(-1, true);

        private void OnDestroy()
        {
            GamePush.GP_Player.OnReady -= OnPlayerReady;
            GamePush.GP_Game.OnPause -= OnPause;
            GamePush.GP_Game.OnResume -= OnResume;
        }

    }
}