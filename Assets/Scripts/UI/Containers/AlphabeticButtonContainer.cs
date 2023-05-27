using System.Collections.Generic;
using System.Linq;
using Systems;
using SO;
using Sounds_container;
using UnityEngine;

namespace UI.Containers
{
    public class AlphabeticButtonContainer : MonoBehaviour
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        [SerializeField] private SoundEffect _clickEffect;
        [Header("Components")]
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

        public void HideLetterButtons(char[] answerValues)
        {
            List<LetterButton> resultLetters = new List<LetterButton>();
            List<LetterButton> hideLetters = new List<LetterButton>();

            int index = 0;
            for (int i = 0; i < answerValues.Length; i++)
            {
                int range = Random.Range(0, _letterButtons.Count);
                hideLetters.Add(_letterButtons[range]);
            }

            while (index < hideLetters.Count - 1)
            {
                var isRepeatLetter = answerValues.Any(x => x == hideLetters[index].Letter);
                if (!isRepeatLetter) 
                    resultLetters.Add(hideLetters[index]);
                
                index++;
            }
            resultLetters.ForEach(x => x.HideLetter());
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
            newLetterButton.ClickedButton += ClickedButton;
        }

        private void ClickedButton(char c)
        {
            _letterOpeningSystem.LetterOpenCheck(c);
            _clickEffect.PlayClip();
        }

        private void OnDisable()
        {
            foreach (LetterButton letterButton in _letterButtons)
                letterButton.ClickedButton -= ClickedButton;
        }
    }
}