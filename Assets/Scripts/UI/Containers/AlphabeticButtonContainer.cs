using System.Collections.Generic;
using Systems;
using SO;
using UnityEngine;

namespace UI.Containers
{
    public class AlphabeticButtonContainer : MonoBehaviour
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        
        [SerializeField] private RectTransform _alphabetContent;
        [SerializeField] private LetterButton _letterButtonPrefab;

        private List<LetterButton> _letterButtons = new List<LetterButton>();
        private LetterOpeningSystem _letterOpeningSystem;
        
        public void Initialize(GameSystemHandlers systemHandlers)
        {
            systemHandlers.SelectedContent += UpdateLetterButtons;
            _letterOpeningSystem = systemHandlers.LetterOpeningSystem;
            InitializeLetterButtons();
        }

        private void UpdateLetterButtons(ContentConfig obj)
        {
            foreach (LetterButton letterButton in _letterButtons)
                letterButton.UpdateLetterButton();
        }

        private void InitializeLetterButtons()
        {
            for (int i = 0; i < RussianAlphabet.Length; i++) 
                CreateLetterButton(i);
        }

        private void CreateLetterButton(int index)
        {
            LetterButton newLetterButton = Instantiate(_letterButtonPrefab, _alphabetContent);
            _letterButtons.Add(newLetterButton);
            
            newLetterButton.Initialize(RussianAlphabet[index]);
            newLetterButton.ClickedButton += _letterOpeningSystem.LetterOpenCheck;
        }

        private void OnDisable()
        {
            foreach (LetterButton letterButton in _letterButtons)
                letterButton.ClickedButton -= _letterOpeningSystem.LetterOpenCheck;
        }
    }
}