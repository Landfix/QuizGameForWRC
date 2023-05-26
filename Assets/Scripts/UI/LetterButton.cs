using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LetterButton : MonoBehaviour
    {
        [SerializeField] private Button _letterAlphabetButton;
        [SerializeField] private TextMeshProUGUI _letterAlphabetText;

        private char _letter;

        public char Letter => _letter;
        
        public event Action<char> ClickedButton;
        
        public void Initialize(char letter)
        {
            _letterAlphabetText.text = letter.ToString();
            _letter = letter;
            _letterAlphabetButton.onClick.AddListener(OnClickHideButton);
        }

        private void OnClickHideButton()
        {
            ClickedButton?.Invoke(_letter);
           HideLetter();
        }

        public void UpdateLetterButton()
        {
            _letterAlphabetButton.interactable = true;
            _letterAlphabetText.alpha = 1f;
        }

        public void HideLetter()
        { 
            _letterAlphabetButton.interactable = false;
            _letterAlphabetText.alpha = 0.5f;
        }

    }
}