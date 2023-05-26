using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Containers
{
    public class WinContainer : MonoBehaviour
    {
        private const string MenuScene = "Menu";
        
        [SerializeField] private Button _playAgainBtn;
        [SerializeField] private Button _menuBtn;

        public void Initialize()
        {
            _playAgainBtn.onClick.AddListener(OnClickPlayAgain);
            _menuBtn.onClick.AddListener(OnClickMenu);
        }

        private void OnClickMenu()
        {
            _playAgainBtn.onClick.RemoveListener(OnClickPlayAgain);
            _menuBtn.onClick.RemoveListener(OnClickMenu);
            SceneManager.LoadScene(MenuScene);
        }

        private void OnClickPlayAgain()
        {
            _playAgainBtn.onClick.RemoveListener(OnClickPlayAgain);
            _menuBtn.onClick.RemoveListener(OnClickMenu);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}