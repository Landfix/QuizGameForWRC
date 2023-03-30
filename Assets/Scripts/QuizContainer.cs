using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuizContainer : MonoBehaviour
    {
        [SerializeField] private QuizConfigs _quizConfigs;
        [Header("Quiz Elements")]
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private QuizButton[] _quizButtons = new QuizButton[4];

        private List<QuizConfig> _quizConfigArray;
        private QuizConfig _selectedQuizConfig;

        public void Initialize()
        {
            _quizConfigArray = _quizConfigs.QuizConfig.ToList();
            SelectRandomQuizElement();

            SetData();
            UpdateData();
        }

        private void UpdateData()
        {
            for (int i = 0; i < _quizButtons.Length; i++)
            {
                _quizButtons[i].UpdateQuiz(_selectedQuizConfig.Answers[i],_selectedQuizConfig.CorrectAnswer);
            }
            
            _icon.sprite = _selectedQuizConfig.Icon;
            _questionText.text = _selectedQuizConfig.Question;
        }

        private void SetData()
        {
            foreach (QuizButton quizButton in _quizButtons)
            {
                quizButton.Initialize();
                quizButton.ClickedCorrectByButton += ClickedCorrectByButton;
            }
            UpdateData();
        }

        private void ClickedCorrectByButton(bool isCorrect)
        {
            SelectRandomQuizElement();
            UpdateData();
            //todo recast
            // if (isCorrect)
            // {
            //     SelectRandomQuizElement();
            //     UpdateData();
            // }
        }

        private void SelectRandomQuizElement()
        {
            int range = Random.Range(0, _quizConfigArray.Count);
            _selectedQuizConfig = _quizConfigArray[range];
            _quizConfigArray.RemoveAt(range);
        }
    }
}