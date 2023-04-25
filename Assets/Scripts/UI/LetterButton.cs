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
        
        public event Action<char> ClickedButton;
        
        public void Initialize(char letter)
        {
            _letterAlphabetText.text = letter.ToString();
            _letter = letter;
            _letterAlphabetButton.onClick.AddListener(ClickButton);
        }

        private void ClickButton()
        {
            ClickedButton?.Invoke(_letter);
            _letterAlphabetButton.interactable = false;
        }

        public void UpdateLetterButton() => 
            _letterAlphabetButton.interactable = true;
    }
}