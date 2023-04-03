using Config;
using UI;
using UnityEngine;

namespace Systems
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private BootstrapperConfig _bootstrapperConfig;
        [SerializeField] private GameUI _gameUi;

        private void Start()
        {
            _gameUi.Initialize(this,_bootstrapperConfig);
        }

        public void EndGame()
        {
        
        }
    }
}
