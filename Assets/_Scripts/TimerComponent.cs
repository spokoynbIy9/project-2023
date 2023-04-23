using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    [SerializeField] private float _secondsToWait;
    [SerializeField] private bool _activateOnStart;
    [SerializeField] private UnityEvent _onTimerEnded;

    private void OnEnable()
    {
        if(_activateOnStart)
            StartTimer();
    }
    public void StartTimer()
    {
        StartCoroutine(WaitForTimer());
    }

    private IEnumerator WaitForTimer()
    {
        yield return new WaitForSeconds(_secondsToWait);
        _onTimerEnded?.Invoke();
    }
}
