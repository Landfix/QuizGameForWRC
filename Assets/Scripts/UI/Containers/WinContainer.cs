using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Containers
{
    public class WinContainer : MonoBehaviour
    {
        [SerializeField] private Button _playAgainBtn;
        [SerializeField] private Button _quitBtn;

        public void Initialize()
        {
            _playAgainBtn.onClick.AddListener(PlayAgain);
            _quitBtn.onClick.AddListener(Quit);
        }

        private void Quit() => 
            Application.Quit();

        private void PlayAgain() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}