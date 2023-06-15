using System;
using System.Collections.Generic;
using SO;

namespace Systems
{
    public class GameSystemHandlers
    {
        private const int DeleteNumberOfPoints = 2; 
        private LetterOpeningSystem _letterOpeningSystem;
        private List<ContentConfig> _contents;
        private ContentConfig _currentContentConfig;

        private int _numberOfAttempts;
        private string _currentlySelectedWord;
        private int _savedNumberOfAttempts;
        
        private Preferences _cachedPreferences;

        public event Action<int> GotPoints;
        public event Action<string> GotQuestion;
        public event Action<int> GotAttempts;

        public event Action WonGame;
        public event Action WonPart;
        public event Action Lost;
        public event Action<ContentConfig> SelectedContent;

        public LetterOpeningSystem LetterOpeningSystem => _letterOpeningSystem;

        public GameSystemHandlers(ContentConfigs contentConfigs)
        {
            _contents = new List<ContentConfig>(contentConfigs.Contents);
            _cachedPreferences = GlobalManager.I.Preferences;
            _numberOfAttempts = contentConfigs.NumberOfAttempts;
            _savedNumberOfAttempts = _numberOfAttempts;
            _letterOpeningSystem = new LetterOpeningSystem();

            _letterOpeningSystem.AttemptTaken += AttemptTaken;
            _letterOpeningSystem.GuessedWord += GuessedWord;
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
            {
                _cachedPreferences.RemovePoints(DeleteNumberOfPoints);
                Lost?.Invoke();
            }
        }

        public void SelectNewContent()
        {
            _currentContentConfig = SetNewContent();
            if (!_currentContentConfig)
            {
                WonGame?.Invoke();
                _letterOpeningSystem.AttemptTaken -= AttemptTaken;
                _letterOpeningSystem.GuessedWord -= GuessedWord;
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

        private void GuessedWord()
        {
            _cachedPreferences.AddPoints(_numberOfAttempts);
            GotPoints?.Invoke(_cachedPreferences.points);
            WonPart?.Invoke();
            SelectNewContent();
        }

        public void Exit()
        {
            _letterOpeningSystem.AttemptTaken -= AttemptTaken;
            _letterOpeningSystem.GuessedWord -= GuessedWord;
        }
    }
}