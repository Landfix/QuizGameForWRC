using System;
using Systems;
using SO;
using TMPro;
using UI.Containers;
using UnityEngine;

namespace UI
{
    public class GameWindow : MonoBehaviour
    {
        private const string PointsHash = "{0} points";
        private const string AttemptsHash = "{0} attempts";
        
        [SerializeField] private ContainerHiddenLetters _containerHiddenLetters;
        [SerializeField] private AlphabeticButtonContainer _alphabeticButtonContainer;
        [SerializeField] private HintsContainer _hintsContainer;
        [SerializeField] private WinContainer _winContainer;
        [Header("Header")]
        [SerializeField] private TextMeshProUGUI _numberOfAttemptsText;
        [SerializeField] private TextMeshProUGUI _numberOfPointsText;
        [SerializeField] private TextMeshProUGUI _questionText;

        private GameSystemHandlers _systemHandlers;
        public void Initialize(GameSystemHandlers systemHandlers)
        {
            _systemHandlers = systemHandlers;
            InitializeContainers();

            _systemHandlers.GotPoints += SetNumberOfPoints;
            _systemHandlers.GotAttempts += SetNumberOfAttempts;
            _systemHandlers.WonGame += OpenWinContainer;
            _systemHandlers.GotQuestion += SetQuestion;
        }

        private void SetQuestion(string question) => 
            _questionText.text = question;

        private void InitializeContainers()
        {
            _containerHiddenLetters.Initialize(_systemHandlers);
            _alphabeticButtonContainer.Initialize(_systemHandlers);
            _hintsContainer.Initialize(_systemHandlers,_alphabeticButtonContainer);
            _winContainer.Initialize();
            _winContainer.gameObject.SetActive(false);
        }

        private void SetNumberOfPoints(int points) => 
            _numberOfPointsText.text = string.Format(PointsHash,points);

        private void SetNumberOfAttempts(int attempts) => 
            _numberOfAttemptsText.text = string.Format(AttemptsHash,attempts);

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
            _systemHandlers.GotQuestion -= SetQuestion;
        }
    }
}