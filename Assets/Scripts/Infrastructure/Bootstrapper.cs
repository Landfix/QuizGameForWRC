using System;
using System.Collections.Generic;
using Programmer_container;
using SO;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ContentConfigs _contentConfigs;
        [SerializeField] private Programmer _programmer;
        [SerializeField] private GameUi _gameUi;
        
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = new GameManager(_gameUi,_programmer,_contentConfigs);
        }

        private void Update() => 
            _gameManager.Update();

        private void OnDisable() => 
            _gameManager.Exit();
    }
}