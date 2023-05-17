using Systems;
using UnityEngine;

namespace UI
{
    public class GameUi : MonoBehaviour
    {
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private WinCurtain _winCurtain;
        [SerializeField] private LoseCurtain _loseCurtain;

        public void Initialize(GameSystemHandlers systemHandlers)
        {
            _winCurtain.Initialize(systemHandlers);
            _loseCurtain.Initialize(systemHandlers);
            _gameWindow.Initialize(systemHandlers);
        }

    }
}