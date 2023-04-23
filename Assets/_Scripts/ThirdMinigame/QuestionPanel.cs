using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionPanel : MonoBehaviour
{
    [SerializeField] private int _rightAnswersCondition;
    [SerializeField] private float _secondsToNextAnswers;
    [SerializeField] private Text _questionText;
    [SerializeField] private VerticalLayoutGroup _answersGroup;
    [SerializeField] private AnswerContainerWidget _answerContainerPrefab;
    
    [SerializeField] private List<QuestionData> _possibleQuestions;

    [SerializeField] private UnityEvent _onAnswer;
    [SerializeField] private UnityEvent _onWrongAnswer;
    [SerializeField] private UnityEvent _onAnsweredAllQuestions;

    private int _rightAnsweredQuestions;

    private List<AnswerContainerWidget> _activeAnswerWidgets = new List<AnswerContainerWidget>();
    private List<QuestionData> _answeredQuestions = new List<QuestionData>();
    
    private QuestionData _currentQuestionData;

    private bool _questionWasAnswered;
    private void Start()
    {
        InitQuestion(GetRandomQuestion());
    }

    private QuestionData GetRandomQuestion()
    {
        if (_currentQuestionData != null)
        {
            _possibleQuestions.Remove(_currentQuestionData);
        }

        if (_possibleQuestions.Count == 0)
        {
            _possibleQuestions = _answeredQuestions.ToList();
            _answeredQuestions.Clear();
        }

        var randomQuestionId = Random.Range(0, _possibleQuestions.Count);
        var randomQuestion = _possibleQuestions[randomQuestionId];
        return randomQuestion;
    }
    private void InitQuestion(QuestionData data)
    {
        ClearSubscribes();
        _questionWasAnswered = false;
        
        _currentQuestionData = data;
        _questionText.text = data.QuestionText;
        if (_activeAnswerWidgets.Count > 0)
        {
            foreach (var widget in _activeAnswerWidgets.ToList())
            {
                Destroy(widget.gameObject);
            }

            _activeAnswerWidgets.Clear();
        }
        InstantinateAnswers(data);
        
        foreach (var widget in _activeAnswerWidgets )
        {
            widget.OnClick += TryApplyAnswer;
        }

    }

    private void InstantinateAnswers(QuestionData data)
    {
        for (int i = 0; i<data.Answers.Count;i++)
        {
            var newAnswer = AnswerContainerWidget.Get(data.Answers[i], 
                _answerContainerPrefab, i+1, _answersGroup.transform);

            _activeAnswerWidgets.Add(newAnswer);
        }
    }

    private void TryApplyAnswer(KeyCode key)
    {
        var id = key.ToInt32();
        id -= 1;
        if(id <0) return;
        
        TryApplyAnswer(id);
    }

    private void TryApplyAnswer(int id)
    {
        // TODO: Поменять логику поиска ответа, если будет время
        var answers = _currentQuestionData.Answers;
        if(answers.Count<=id) return;
        
        var answer = answers[id];
        _activeAnswerWidgets[id].Activate(answer.IsCorrect);
        _onAnswer?.Invoke();
        if (answer.IsCorrect)
        {
            _rightAnsweredQuestions++;
            if(_rightAnsweredQuestions == _rightAnswersCondition)
                _onAnsweredAllQuestions?.Invoke();
        }
        else
        {
            _onWrongAnswer?.Invoke();
        }

        _answeredQuestions.Add(_currentQuestionData);
        _questionWasAnswered = true;

        StartCoroutine(WaitForNextQuestion());
    }
    private void OnGUI()
    {
        Event currentEvent = Event.current;
        if (_questionWasAnswered == false && currentEvent.isKey)
        {
            TryApplyAnswer(currentEvent.keyCode);
        }
    }

    private IEnumerator WaitForNextQuestion()
    {
        yield return new WaitForSeconds(_secondsToNextAnswers);
        InitQuestion(GetRandomQuestion());
    }

    private void ClearSubscribes()
    {
        foreach (var widget in _activeAnswerWidgets )
        {
            widget.OnClick -= TryApplyAnswer;
        }
    }

    private void OnDestroy()
    {
        ClearSubscribes();
    }
}

public static class KeyCodeExtension
{
    public static int ToInt32(this KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Alpha0:
                return 0;
            case KeyCode.Alpha1:
                return 1;
            case KeyCode.Alpha2:
                return 2;
            case KeyCode.Alpha3:
                return 3;
            case KeyCode.Alpha4:
                return 4;
            case KeyCode.Alpha5:
                return 5;
            case KeyCode.Alpha6:
                return 6;
            case KeyCode.Alpha7:
                return 7;
            case KeyCode.Alpha8:
                return 8;
            case KeyCode.Alpha9:
                return 9;
            default:
                return -1;
        }
    }
}
