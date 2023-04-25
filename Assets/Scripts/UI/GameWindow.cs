using System;
using Systems;
using TMPro;
using UI.Containers;
using UnityEngine;

namespace UI
{
    public class GameWindow : MonoBehaviour
    {
        [SerializeField] private ContainerHiddenLetters _containerHiddenLetters;
        [SerializeField] private AlphabeticButtonContainer _alphabeticButtonContainer;
        [SerializeField] private WinContainer _winContainer;

        [SerializeField] private TextMeshProUGUI _numberOfAttemptsText;
        [SerializeField] private TextMeshProUGUI _numberOfPointsText;

        private GameSystemHandlers _systemHandlers;
        public void Initialize(GameSystemHandlers systemHandlers)
        {
            _systemHandlers = systemHandlers;
            InitializeContainers();

            _systemHandlers.GotPoints += SetNumberOfPoints;
            _systemHandlers.GotAttempts += SetNumberOfAttempts;
            _systemHandlers.WonGame += OpenWinContainer;
        }

        private void InitializeContainers()
        {
            _containerHiddenLetters.Initialize(_systemHandlers);
            _alphabeticButtonContainer.Initialize(_systemHandlers);
            _winContainer.Initialize();
            _winContainer.gameObject.SetActive(false);
        }

        private void SetNumberOfPoints(int points) => 
            _numberOfPointsText.text = $"{points} points";

        private void SetNumberOfAttempts(int attempts) => 
            _numberOfAttemptsText.text = $"{attempts} attempts";

        private void OpenWinContainer()
        {
            Unsubscribe();
            _winContainer.gameObject.SetActive(true);
        }

        private void OnDisable() => 
            Unsubscribe();

        private void Unsubscribe()
        {
            _systemHandlers.GotPoints -= SetNumberOfPoints;
            _systemHandlers.GotAttempts -= SetNumberOfAttempts;
            _systemHandlers.WonGame -= OpenWinContainer;
        }
    }
}