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

        public GameManager(GameUi gameUi, ContentConfigs contentConfigs)
        {
            _gameSystemHandlers = new GameSystemHandlers(contentConfigs);
            gameUi.Initialize(_gameSystemHandlers);
            _gameSystemHandlers.SelectNewContent();
        }

        public void Update() => 
            _gameSystemHandlers.Update();

        public void Exit() => 
            _gameSystemHandlers.Exit();
    }
}