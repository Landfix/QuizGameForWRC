using System;
using System.Collections.Generic;
using System.Linq;
using UI;

namespace Systems
{
    public class LetterOpeningSystem
    {
        private List<CardView> _cards = new List<CardView>();
        
        public event Action AttemptTaken;
        public event Action GuessedWord;
        
        public void Update()
        {
            if (CheckWin()) 
                GuessedWord?.Invoke();
        }

        public void UpdateCards(List<CardView> cards) => 
            _cards = cards;

        public void LetterOpenCheck(char c)
        {
            bool anyOpened = false;
            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                if (_cards[i].Letter == c)
                {
                    if (!_cards[i].IsShown)
                    {
                        anyOpened = true;
                        _cards[i].ShowText();
                    }
                }
            }

            if (!anyOpened) 
                AttemptTaken?.Invoke();
        }
        
        private bool CheckWin() => 
            _cards.All(x => x.IsShown);
    }
}