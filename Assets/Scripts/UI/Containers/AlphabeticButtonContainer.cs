using System.Collections.Generic;
using Systems;
using UnityEngine;

namespace UI.Containers
{
    public class AlphabeticButtonContainer : MonoBehaviour
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        [SerializeField] private RectTransform _alphabetContent;
        [SerializeField] private LetterButton _letterButtonPrefab;

        private List<LetterButton> _letterButtons = new List<LetterButton>();
        private LetterOpeningSystem _letterOpeningSystem;
        
        public void Initialize(GameSystemHandlers systemHandlers)
        {
            systemHandlers.SelectedWord += UpdateLetterButtons;
            _letterOpeningSystem = systemHandlers.LetterOpeningSystem;
            InitializeLetterButtons();
        }

        private void InitializeLetterButtons()
        {
            for (int i = 0; i < EnglishAlphabet.Length; i++) 
                CreateLetterButton(i);
        }

        private void UpdateLetterButtons(string obj)
        {
            foreach (LetterButton letterButton in _letterButtons)
                letterButton.UpdateLetterButton();
        }

        private void CreateLetterButton(int index)
        {
            LetterButton newLetterButton = Instantiate(_letterButtonPrefab, _alphabetContent);
            _letterButtons.Add(newLetterButton);
            
            newLetterButton.Initialize(EnglishAlphabet[index]);
            newLetterButton.ClickedButton += _letterOpeningSystem.LetterOpenCheck;
        }

        private void OnDisable()
        {
            foreach (LetterButton letterButton in _letterButtons)
                letterButton.ClickedButton -= _letterOpeningSystem.LetterOpenCheck;
        }
    }
}