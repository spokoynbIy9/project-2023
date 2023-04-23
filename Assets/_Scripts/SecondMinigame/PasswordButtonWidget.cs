using System;
using UnityEngine;
using UnityEngine.UI;

public class PasswordButtonWidget : MonoBehaviour
{
    [SerializeField] private int _number;
    
    [SerializeField] private Button _button;

    public Action<int> OnButtonPressed;

    protected void Awake()
    {
        _button.onClick.AddListener(ButtonPressCallback);
    }

    private void ButtonPressCallback()
    {
        OnButtonPressed?.Invoke(_number);
    }

    protected void OnDestroy()
    {
        _button.onClick.RemoveListener(ButtonPressCallback);
    }
    
}
