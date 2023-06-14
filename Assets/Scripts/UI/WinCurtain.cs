using System;
using Systems;
using DG.Tweening;
using Sounds_container;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WinCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _correctIconTransform;
        [Header("Sounds")] 
        [SerializeField] private SoundEffect _soundEffect; 
        
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
            _correctIconTransform.DOScale(Vector2.one * 3, 0.3f).SetEase(Ease.Flash);
            _soundEffect.PlayClip();
        }

        private void ShowCurtain()
        {
            _canvasGroup.DOFade(1f, 0.3f).SetEase(Ease.Flash).OnComplete(HideCurtain);
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void HideCurtain()
        {
            _canvasGroup.DOFade(0f, 0.1f).SetEase(Ease.Flash);
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
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