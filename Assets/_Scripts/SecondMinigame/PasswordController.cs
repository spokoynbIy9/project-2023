using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PasswordController : MonoBehaviour
{

    [SerializeField] private PasswordContainer _passwordContainer;
    [SerializeField] private List<PasswordButtonWidget> _passwordButtons;

    [SerializeField] private Button _applyButton;
    [SerializeField] private UnityEvent _onCorrectPasswordEntered;

    public Action<bool> OnApplyButtonPressed;

    private void Awake()
    {
        foreach (var button in _passwordButtons)
        {
            button.OnButtonPressed += _passwordContainer.AddNumberInCombination;
        }
        _applyButton.onClick.AddListener(TryApplyPassword);
    }

    private void TryApplyPassword()
    {
        var result = _passwordContainer.TryApplyPassword();
        if(result)
            _onCorrectPasswordEntered?.Invoke();
        OnApplyButtonPressed?.Invoke(result);
    }

    private void OnDestroy()
    {
        foreach (var button in _passwordButtons)
        {
            button.OnButtonPressed -= _passwordContainer.AddNumberInCombination;
        }
        _applyButton.onClick.RemoveListener(TryApplyPassword);
    }
}
