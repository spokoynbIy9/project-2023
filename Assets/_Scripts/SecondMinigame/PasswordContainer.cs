using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordContainer : MonoBehaviour
{
    [SerializeField] private List<int> _correctPassword = new List<int>();

    private List<int> _currentCombination = new List<int>();

    public Action<List<int>> OnPasswordCombinationChanged;

    public void AddNumberInCombination(int number)
    {
        _currentCombination.Add(number);
        OnPasswordCombinationChanged?.Invoke(_currentCombination);
    }

    public bool TryApplyPassword()
    {
        var result = GetApplyPasswordResult();

        _currentCombination.Clear();
        
        return result;
    }
    private bool GetApplyPasswordResult()
    {
        if (_correctPassword.Count != _currentCombination.Count) return false;
        
        for (int i = 0; i < _currentCombination.Count; i++)
            if (_currentCombination[i] != _correctPassword[i])
                return false;

        return true;
    }
}
