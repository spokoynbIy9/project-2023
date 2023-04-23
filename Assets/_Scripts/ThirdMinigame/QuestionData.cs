using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "ThirdGame/Question")]
public class QuestionData : ScriptableObject
{
    [SerializeField] private string _questionText;
    [SerializeField] private List<AnswerData> _answers;
    
    public string QuestionText => _questionText;
    public List<AnswerData> Answers => _answers;
}

[Serializable]
public class AnswerData
{
    [SerializeField] private string _text;
    [SerializeField] private bool _isCorrect;

    public string Text => _text;
    public bool IsCorrect => _isCorrect;
}
