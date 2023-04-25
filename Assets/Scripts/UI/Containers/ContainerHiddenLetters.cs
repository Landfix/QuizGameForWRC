using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Containers
{
    public class ContainerHiddenLetters : MonoBehaviour
    {
        private const int ExtraStep = 2;
        
        [SerializeField] private RectTransform _cardContent;
        [SerializeField] private GridLayoutGroup _gridGroup;
        [SerializeField] private CardView cardViewPrefab;
        
        private GameSystemHandlers _systemHandlers;
        private List<CardView> _cards = new List<CardView>();
        private string _currentWord;
        
        public event Action<List<CardView>> CreatedCards;

        public void Initialize(GameSystemHandlers systemHandlers)
        {
            _systemHandlers = systemHandlers;
            _systemHandlers.SelectedWord += SelectedWord;
            CreatedCards += _systemHandlers.LetterOpeningSystem.UpdateCards;
        }

        private void SelectedWord(string word)
        {
            CardCleaning();
            _currentWord = word;
            float cellValue = (_cardContent.sizeDelta.x - _gridGroup.spacing.x) / (_currentWord.Length + ExtraStep);
            _gridGroup.cellSize = new Vector2(cellValue, cellValue);

            InitializeCards(word);
        }

        private void InitializeCards(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                CreateCard(word[i]);
            }
            
            CreatedCards?.Invoke(_cards);
        }

        private void CreateCard(char letter)
        {
            CardView newCard = Instantiate(cardViewPrefab, _cardContent);
            _cards.Add(newCard);
            newCard.Initialize(letter);
        }

        private void CardCleaning()
        {
            for (int i = 0; i < _cards.Count; i++) 
                Destroy(_cards[i].gameObject);
            
            _cards.Clear();
        }

        private void OnDisable()
        {
            _systemHandlers.SelectedWord -= SelectedWord;
            CreatedCards -= _systemHandlers.LetterOpeningSystem.UpdateCards;
        }
    }
}