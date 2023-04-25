using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _letterText;

        public char Letter { get; private set; }
        public bool IsShown { get; private set; }

        public void Initialize(char letter)
        {
            HideText();
            _letterText.text = letter.ToString();
            Letter = letter;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K)) 
                ShowText();
        }

        public void ShowText() => 
            StartCoroutine(ShowTextCoroutine(0.1f));

        private IEnumerator ShowTextCoroutine(float step)
        {
            Color startColor = _letterText.color;
            while (_letterText.color.a < 1)
            {
                startColor.a += step;
                _letterText.color = startColor;
                yield return null;
            }
            
            IsShown = true;
        }

        private void HideText()
        {
            Color color = _letterText.color;
            color.a = 0;
            _letterText.color = color;
        }
    }
}