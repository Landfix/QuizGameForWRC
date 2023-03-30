using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TimeContainer _timeContainer;

        public void Initialize()
        {
            
        }
    }

    public class TimeContainer : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        private float _duration;
        
        public void Initialize(float duration)
        {
            _duration = duration;

            //StartCoroutine(ActivateTimerCoroutine());
        }

        // private IEnumerator ActivateTimerCoroutine()
        // {
        // }
    }
}