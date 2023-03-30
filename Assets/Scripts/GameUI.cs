using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace DefaultNamespace
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TimeContainer _timeContainer;

        private Bootstrapper _bootstrapper;

        public void Initialize(Bootstrapper bootstrapper, float duration)
        {
            _bootstrapper = bootstrapper;
            _timeContainer.Initialize(duration);
            _timeContainer.TimeIsUp += _bootstrapper.EndGame;
        }
    }

    public class TimeContainer : MonoBehaviour
    {
        [SerializeField] private Image _barImg;

        private float _duration;

        public event Action TimeIsUp;
        
        public void Initialize(float duration)
        {
            _duration = duration;
            _barImg.DOFillAmount(0, _duration).OnComplete(() => { TimeIsUp?.Invoke();});
        }

        // private IEnumerator ActivateTimerCoroutine()
        // {
        // }
    }
}