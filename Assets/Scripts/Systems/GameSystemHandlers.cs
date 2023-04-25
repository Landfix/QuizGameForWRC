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
        private List<ContentConfig> _contents;
        private ContentConfig _currentContentConfig;

        private int _numberOfPoints;
        private int _numberOfAttempts;
        private string _currentlySelectedWord;

        private int _savedNumberOfAttempts;

        public event Action<int> GotPoints;
        public event Action<string> GotQuestion;
        public event Action<int> GotAttempts;

        public event Action WonGame;
        public event Action<ContentConfig> SelectedContent;

        public LetterOpeningSystem LetterOpeningSystem => _letterOpeningSystem;

        public GameSystemHandlers(ContentConfigs contentConfigs)
        {
            _contents = new List<ContentConfig>(contentConfigs.Contents);
            _numberOfAttempts = contentConfigs.NumberOfAttempts;
            _savedNumberOfAttempts = _numberOfAttempts;
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

        public void SelectNewContent()
        {
            _currentContentConfig = SetNewContent();
            if (!_currentContentConfig)
            {
                WonGame?.Invoke();
                return;
            }

            SelectedContent?.Invoke(_currentContentConfig);
            GotQuestion?.Invoke(_currentContentConfig.Question);
            _numberOfAttempts = _savedNumberOfAttempts;
            GotAttempts?.Invoke(_numberOfAttempts);
        }

        public void Update() => 
            _letterOpeningSystem.Update();

        private ContentConfig SetNewContent()
        {
            if (_contents.Count < 1)
                return null;

            int randomIndex = UnityEngine.Random.Range(0, _contents.Count);
            ContentConfig contentConfig = _contents[randomIndex];
            _contents.RemoveAt(randomIndex);

            return contentConfig;
        }

        private void AddNewPoints()
        {
            _numberOfPoints += _numberOfAttempts;
            GotPoints?.Invoke(_numberOfPoints);

            SelectNewContent();
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