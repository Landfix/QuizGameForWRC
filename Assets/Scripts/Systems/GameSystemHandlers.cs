using System;
using System.Collections.Generic;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class GameSystemHandlers
    {
        private LetterOpeningSystem _letterOpeningSystem;
        private ContentConfig _contentConfig;
        private List<string> _uniqueWords;

        private int _numberOfPoints;
        private int _numberOfAttempts;
        private string _currentlySelectedWord;

        public event Action<int> GotPoints;
        public event Action<int> GotAttempts;

        public event Action WonGame;
        public event Action<string> SelectedWord;

        public LetterOpeningSystem LetterOpeningSystem => _letterOpeningSystem;

        public GameSystemHandlers(List<string> uniqueWords, ContentConfig contentConfig)
        {
            _contentConfig = contentConfig;
            _numberOfAttempts = _contentConfig.NumberOfAttempts;
            _uniqueWords = uniqueWords;
            _numberOfPoints = 0;

            _letterOpeningSystem = new LetterOpeningSystem();

            _letterOpeningSystem.AttemptTaken += AttemptTaken;
            _letterOpeningSystem.GuessedWord += AddNewPoints;
            GotAttempts?.Invoke(_numberOfAttempts);
        }

        private void AttemptTaken()
        {
            if (_numberOfAttempts > 0)
            {
                _numberOfAttempts -= 1;
                GotAttempts?.Invoke(_numberOfAttempts);
            }
            else
                RestartScene();

        }

        public void SelectNewWord()
        {
            _currentlySelectedWord = GenerateWord();
            if (_currentlySelectedWord == null)
            {
                WonGame?.Invoke();
                return;
            }

            SelectedWord?.Invoke(_currentlySelectedWord);
            _numberOfAttempts = _contentConfig.NumberOfAttempts;
            GotAttempts?.Invoke(_numberOfAttempts);
        }

        public void Update() => 
            _letterOpeningSystem.Update();

        private string GenerateWord()
        {
            if (_uniqueWords.Count < 1)
                return null;

            int randomIndex = UnityEngine.Random.Range(0, _uniqueWords.Count);
            string word = _uniqueWords[randomIndex];
            _uniqueWords.RemoveAt(randomIndex);

            return word;
        }

        private void AddNewPoints()
        {
            _numberOfPoints += _numberOfAttempts;
            GotPoints?.Invoke(_numberOfPoints);

            SelectNewWord();
        }

        private void RestartScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void Exit()
        {
            _letterOpeningSystem.AttemptTaken -= AttemptTaken;
            _letterOpeningSystem.GuessedWord -= AddNewPoints;
        }
    }
}