using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConstBarWidget : MonoBehaviour
{
    [SerializeField] private ConstObserver _constObserver;

    [SerializeField] private Image _bar;

    private void Awake()
    {
        _constObserver.OnCurrentChargeChanged += UpdateBar;
    }

    private void UpdateBar( float value)
    {
        _bar.fillAmount = value;
    }

    private void OnDestroy()
    {
        _constObserver.OnCurrentChargeChanged -= UpdateBar;
    }
}
