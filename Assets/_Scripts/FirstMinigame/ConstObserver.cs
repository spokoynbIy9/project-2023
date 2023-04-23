using System;
using System.Collections;
using System.Collections.Generic;
using NewtonGame.FirstMinigame;
using UnityEngine;
using UnityEngine.Events;

public class ConstObserver : MonoBehaviour
{
    [SerializeField] private SpeedController _speedController;
    [SerializeField] private float _constValue;
    [SerializeField] private float _tolerance;
    [SerializeField] private float _chargeSpeed;
    [SerializeField] private UnityEvent _onConstCharged;
    public Action<float> OnCurrentChargeChanged;

    private float _currentCharge;
    private void Update()
    {
        if (Math.Abs(_speedController.CurrentSpeedX - _constValue) < _tolerance)
        {
            _currentCharge += _chargeSpeed * Time.deltaTime;
        }
        else
        {
            _currentCharge = 0;
        }
        OnCurrentChargeChanged?.Invoke(_currentCharge);
        if (_currentCharge > 0.98f)
        {
            _onConstCharged?.Invoke();
        }
    }
}


