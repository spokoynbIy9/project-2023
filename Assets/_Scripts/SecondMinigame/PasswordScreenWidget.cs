using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PasswordScreenWidget : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private PasswordContainer _passwordContainer;
    [SerializeField] private PasswordController _passwordController;
    
    [SerializeField] private Image _screenBackground;
    [SerializeField] private Color _correctPasswordColor;
    [SerializeField] private Color _wrongPasswordColor;
    [SerializeField] private float _changeColorTime;
    
    private Color _defaultColor;

    private void Awake()
    {
        _passwordContainer.OnPasswordCombinationChanged += UpdateText;
        _passwordController.OnApplyButtonPressed += ApplyCallback;
        
        _defaultColor = _screenBackground.color;
    }

    private void UpdateText(List<int> passwordCombination)
    {
        _screenBackground.color = _defaultColor;
        
        StringBuilder newPassword =  new StringBuilder();
        foreach (var number in passwordCombination)
        {
            newPassword.Append(number.ToString());
        }

        _text.text = newPassword.ToString();
    }

    private void ApplyCallback(bool applyResult)
    {
        var color = applyResult ? _correctPasswordColor : _wrongPasswordColor;
        _screenBackground.color = color;
    }

    private void OnDestroy()
    {
        _passwordContainer.OnPasswordCombinationChanged -= UpdateText;
        _passwordController.OnApplyButtonPressed-= ApplyCallback;
    }
}
