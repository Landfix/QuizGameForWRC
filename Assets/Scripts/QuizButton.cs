using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [Header("Colors")] 
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _incorrectColor;

    private string _correctAnswer;
    private string _answer;
    private Image _cachedBtnImg;

    public event Action<bool> ClickedCorrectByButton;
        
    public void Initialize()
    {
        _button.onClick.AddListener(OnClickButton);
        _cachedBtnImg = _button.image;
    }

    private void OnClickButton()
    {
        StartCoroutine(_correctAnswer == _answer 
            ? AnsweredCorrectlyCoroutine() : AnsweredIncorrectlyCoroutine());
    }

    public void UpdateQuiz(string answer, string correctAnswer)
    {
        _correctAnswer = correctAnswer;
        _answer = answer;
        _text.text = _answer;
    }

    private IEnumerator AnsweredCorrectlyCoroutine()
    {
        _cachedBtnImg.color = _correctColor;
        yield return new WaitForSeconds(0.7f);
        _cachedBtnImg.color = Color.white;
        ClickedCorrectByButton?.Invoke(true);
    }

    private IEnumerator AnsweredIncorrectlyCoroutine()
    {
        _cachedBtnImg.color = _incorrectColor;
        yield return new WaitForSeconds(0.7f);
        _cachedBtnImg.color = Color.white;
        ClickedCorrectByButton?.Invoke(false);
    }
}