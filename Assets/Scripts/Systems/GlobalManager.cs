﻿using Sounds_container;
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
            // GameScore.GS_SDK.OnReady += OnReady;
            // GameScore.GS_Player.OnPlayerReady += OnPlayerReady;
            // GameScore.GS_Game.OnPause += OnPause;
            // GameScore.GS_Game.OnResume += OnResume;
            
            // todo delete
            _preferences.Init();
            _musicEffect.Initialize(_preferences);
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
            // GameScore.GS_SDK.OnReady -= OnReady;
            // GameScore.GS_Player.OnPlayerReady -= OnPlayerReady;
            // GameScore.GS_Game.OnPause -= OnPause;
            // GameScore.GS_Game.OnResume -= OnResume;
        }

    }
}