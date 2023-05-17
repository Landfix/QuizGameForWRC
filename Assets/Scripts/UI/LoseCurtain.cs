using Systems;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoseCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private GameSystemHandlers _gameSystemHandlers;
        
        public void Initialize(GameSystemHandlers gameSystemHandlers)
        {
            _gameSystemHandlers = gameSystemHandlers;
            _gameSystemHandlers.Lost += ShowCurtain;
            SharpHideCurtain();
        }

        private void ShowCurtain()
        {
            _canvasGroup.DOFade(1f, 0.3f).SetEase(Ease.Flash).OnComplete(HideCurtain);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void HideCurtain()
        {
            _canvasGroup.DOFade(0f, 0.3f).SetEase(Ease.Flash).OnComplete(RestartScene);
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
        
        private void SharpHideCurtain()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void RestartScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void OnDestroy()
        {
            _gameSystemHandlers.Lost -= ShowCurtain;
        }
    }
}