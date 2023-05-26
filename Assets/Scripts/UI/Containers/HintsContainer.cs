using Systems;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Containers
{
    public class HintsContainer : MonoBehaviour
    {
        [SerializeField] private Button _openLetterBtn;
        [SerializeField] private Button _hideLettersBtn;

        private AlphabeticButtonContainer _alphabeticButtonContainer;
        private GameSystemHandlers _systemHandlers;
        private string _answer;

        public void Initialize(GameSystemHandlers systemHandlers, AlphabeticButtonContainer alphabeticButtonContainer)
        {
            _systemHandlers = systemHandlers;
            _alphabeticButtonContainer = alphabeticButtonContainer;
            _openLetterBtn.onClick.AddListener(OnClickOpenLetter);
            _hideLettersBtn.onClick.AddListener(OnClickHideLetters);
            _systemHandlers.SelectedContent += SelectedContent;
        }

        private void SelectedContent(ContentConfig config) => _answer = config.Answer;

        private void OnClickHideLetters() => 
            _alphabeticButtonContainer.HideLetterButtons(_answer.ToCharArray());

        private void OnClickOpenLetter() => 
            _systemHandlers.LetterOpeningSystem.OpenRandomLetter();

        private void OnDestroy()
        {
            _openLetterBtn.onClick.RemoveListener(OnClickOpenLetter);
            _hideLettersBtn.onClick.RemoveListener(OnClickHideLetters);
            _systemHandlers.SelectedContent -= SelectedContent;
        }
    }
}