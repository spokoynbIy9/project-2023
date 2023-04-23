using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpaceBarBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private float _timeToStartDecrease;
    [SerializeField] private float _decreaseSpeed;
    [SerializeField] private float _stepCount;
    [SerializeField] private UnityEvent _onFilled;
    private float _step;
    
    private float _currentValue;
   [SerializeField] private float _timeFromPreviousPress;

    private void Awake()
    {
        UpdateStepValue();
    }

    private void UpdateStepValue()
    {
        _bar.fillAmount = 0;
        _step =  100 / _stepCount / 100;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bar.fillAmount += _step;
            if (_bar.fillAmount > 0.99f)
            {
                _onFilled?.Invoke();
            }

            _timeFromPreviousPress = 0;
        }
        else
        {
            _timeFromPreviousPress += Time.deltaTime;
        }

        if (_timeFromPreviousPress >= _timeToStartDecrease)
        {
            _bar.fillAmount -= _decreaseSpeed * Time.deltaTime;
        }
    }

    public void UpdateSteps(float value)
    {
        _stepCount = value;
        UpdateStepValue();
    }
    
}
