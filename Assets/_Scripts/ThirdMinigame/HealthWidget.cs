using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWidget : MonoBehaviour
{
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private LayoutGroup _heartsParrent;
    [SerializeField] private Image _heartPrefab;

    private Stack<Image> _hearts = new Stack<Image>();

    private void Awake()
    {
        _healthComponent.OnHealthChanged += UpdateHeartsCount;
        for (int i = 0; i < _healthComponent.Health; i++)
        {
            var heart = Instantiate(_heartPrefab, _heartsParrent.transform);
            _hearts.Push(heart);
        }
    }

    private void UpdateHeartsCount(int removeCount)
    {
        if(_hearts.Count<=0) return;
        
        var heart = _hearts.Pop();
        Destroy(heart.gameObject);
    }

    private void OnDestroy()
    {
        _healthComponent.OnHealthChanged -= UpdateHeartsCount;
    }
}
