using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
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
    }
}