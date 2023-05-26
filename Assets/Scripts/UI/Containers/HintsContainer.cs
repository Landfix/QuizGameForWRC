using Systems;
using SO;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Containers
{
    public class HintsContainer : MonoBehaviour
    {
        [SerializeField] private Button _getLetterBtn;
        [SerializeField] private Button _hideLettersBtn;

        private AlphabeticButtonContainer _alphabeticButtonContainer;
        private GameSystemHandlers _systemHandlers;
        private string _answer;

        public void Initialize(GameSystemHandlers systemHandlers, AlphabeticButtonContainer alphabeticButtonContainer)
        {
            _systemHandlers = systemHandlers;
            _alphabeticButtonContainer = alphabeticButtonContainer;
            _getLetterBtn.onClick.AddListener(OnClickGetLetter);
            _hideLettersBtn.onClick.AddListener(OnClickHideLetters);
            _systemHandlers.SelectedContent += SelectedContent;
        }

        private void SelectedContent(ContentConfig config)
        {
            _answer = config.Answer;
        }

        private void OnClickHideLetters()
        {
            _alphabeticButtonContainer.HideLetterButtons(_answer.ToCharArray());
        }

        private void OnClickGetLetter()
        {
            _systemHandlers.LetterOpeningSystem.OpenRandomLetter();
        }

        private void OnDestroy()
        {
            _systemHandlers.SelectedContent -= SelectedContent;
        }
    }
}