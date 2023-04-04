using System.Collections.Generic;
using System.Linq;
using Systems;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizContainer : MonoBehaviour
{
    private const string MenuScene = "Menu";
    
    [SerializeField] private ThemeConfigs _themeConfigs;
    [Header("Quiz Elements")]
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private QuizButton[] _quizButtons = new QuizButton[4];

    private List<QuizConfig> _quizConfigArray;
    private QuizConfig _selectedQuizConfig;
    private Preferences _cachedPreferences;

    public void Initialize()
    {
        _cachedPreferences = GlobalManager.I.Preferences;
        ThemeConfig themeConfig = _themeConfigs.ThemeConfig.
            FirstOrDefault(x => x.ThemeType == (ThemeType)_cachedPreferences.theme);
        _quizConfigArray = themeConfig.QuizConfigs.ToList();
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
            quizButton.ClickedCorrectByButton += UpdateQuiz;
        }
        UpdateData();
    }

    public void UpdateQuiz(bool isCorrect)
    {
        if (_quizConfigArray.Count <= 0)
        {
            SceneManager.LoadScene(MenuScene);
        }
        else
        {
            SelectRandomQuizElement();
            UpdateData();   
        }
    }

    private void SelectRandomQuizElement()
    {
        int range = Random.Range(0, _quizConfigArray.Count);
        _selectedQuizConfig = _quizConfigArray[range];
        _quizConfigArray.RemoveAt(range);
    }
}