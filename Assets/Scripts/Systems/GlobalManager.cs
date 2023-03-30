using DefaultNamespace.Utils;
using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalManager : SingletonMono<GlobalManager>
    {
        private readonly Preferences _preferences = new Preferences();
        
        public Preferences Preferences => _preferences;

        public override void Awake()
        {
            base.Awake();
            _preferences.Init();
        }
    }
}