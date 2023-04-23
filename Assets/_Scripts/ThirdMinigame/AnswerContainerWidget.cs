using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerContainerWidget : MonoBehaviour
{
    [SerializeField] private Text _numberText;
    [SerializeField] private Text _answerText;
    
    public Action<int> OnClick;

    private int _number;
    public int Number => _number;

    public static AnswerContainerWidget Get(AnswerData answerData, AnswerContainerWidget prefab, int number, Transform parrent)
    {
        var answerContainer = Instantiate(prefab, parrent);
        answerContainer.Init(number, answerData.Text);
        return answerContainer;
    }
    public void Init(int number, string text)
    {
        _number = number;
        _numberText.text = number.ToString();
        _answerText.text = text;
    }
    public void DoOnClickEvent()
    {
        OnClick?.Invoke(Number - 1);
    }

    public void Activate(bool isCorrect)
    {
        var color = isCorrect ? Color.green : Color.red;
        _answerText.color = color;
    }
}
