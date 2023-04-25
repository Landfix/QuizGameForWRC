using Systems;
using UnityEngine;

namespace UI
{
    public class GameUi : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;

        public void Initialize(GameSystemHandlers systemHandlers) => 
            _gameWindow.Initialize(systemHandlers);
    }
}