using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private BootstrapperConfig _bootstrapperConfig;
    [SerializeField] private GameUI _gameUi;

    private void Start()
    {
        _gameUi.Initialize(this,_bootstrapperConfig);
    }

    public void EndGame()
    {
        
    }
}
