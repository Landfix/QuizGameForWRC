using System;
using Systems;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WinCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _correctIconTransform;
        
        private GameSystemHandlers _gameSystemHandlers;
        
        public void Initialize(GameSystemHandlers gameSystemHandlers)
        {
            _gameSystemHandlers = gameSystemHandlers;
            _gameSystemHandlers.WonPart += WonPart;
            SharpHideCurtain();
        }

        private void WonPart()
        {
            ShowCurtain();
            // _correctIconTransform.DOScale(Vector2.one * 3, 0.4f).SetEase(Ease.Flash)
            //     .OnComplete(GlobalManager.I.LevelSkip);
        }

        private void ShowCurtain()
        {
            // _canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.Flash);
            // _canvasGroup.interactable = true;
            // _canvasGroup.blocksRaycasts = true;
        }

        public void HideCurtain()
        {
            // _canvasGroup.DOFade(0f, 1f).SetEase(Ease.Flash);
            // _canvasGroup.interactable = false;
            // _canvasGroup.blocksRaycasts = false;
        }

        private void SharpHideCurtain()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void OnDestroy()
        {
            _gameSystemHandlers.WonPart -= WonPart;
        }
    }
}