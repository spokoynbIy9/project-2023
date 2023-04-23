using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AnswerContainerWidget _answerContainer;
    [SerializeField] private UnityEvent<int> _onClick;

    private void Awake()
    {
        _button.onClick.AddListener(DoOnClickEvent);
    }

    private void DoOnClickEvent()
    {
        _onClick?.Invoke(_answerContainer.Number);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(DoOnClickEvent);
    }
}
