using System;
using System.Collections.Generic;
using Systems;
using Programmer_container;
using SO;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameManager
    {
        private readonly GameSystemHandlers _gameSystemHandlers;

        public GameManager(GameUi gameUi, Programmer programmer, ContentConfigs contentConfigs)
        {
            _gameSystemHandlers = new GameSystemHandlers(contentConfigs);
            programmer.Initialize(_gameSystemHandlers);
            gameUi.Initialize(_gameSystemHandlers);
            _gameSystemHandlers.SelectNewContent();
        }

        public void Update() => 
            _gameSystemHandlers.Update();

        public void Exit() => 
            _gameSystemHandlers.Exit();
    }
}