using System;
using System.Collections.Generic;
using Systems;
using SO;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameManager
    {
        private readonly GameSystemHandlers _gameSystemHandlers;

        public GameManager(GameUi gameUi, List<string> uniqueWords, ContentConfig contentConfig)
        {
            _gameSystemHandlers = new GameSystemHandlers(uniqueWords,contentConfig);
            gameUi.Initialize(_gameSystemHandlers);
            _gameSystemHandlers.SelectNewWord();
        }

        public void Update() => 
            _gameSystemHandlers.Update();

        public void Exit() => 
            _gameSystemHandlers.Exit();
    }
}