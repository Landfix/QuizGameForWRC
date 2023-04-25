using System;
using System.Collections.Generic;
using SO;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ContentConfig _contentConfig;
        [SerializeField] private GameUi _gameUi;
        
        private LoaderWords _loaderWords;
        private GameManager _gameManager;
        
        private List<string> _uniqueWords;
        private string _currentlySelectedWord;

        private async void Start()
        {
            _loaderWords = new LoaderWords(_contentConfig);
            _uniqueWords = await _loaderWords.LoadingWords();
            _gameManager = new GameManager(_gameUi, _uniqueWords,_contentConfig);
        }

        private void Update() => 
            _gameManager.Update();

        private void OnDisable() => 
            _gameManager.Exit();
    }
}