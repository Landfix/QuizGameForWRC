using System;
using System.Collections.Generic;
using SO;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ContentConfigs _contentConfigs;
        [SerializeField] private GameUi _gameUi;
        
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = new GameManager(_gameUi,_contentConfigs);
        }

        private void Update() => 
            _gameManager.Update();

        private void OnDisable() => 
            _gameManager.Exit();
    }
}