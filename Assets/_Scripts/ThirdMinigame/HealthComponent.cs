using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _onDeathEvent;

    public int Health => _health;
    public Action<int> OnHealthChanged;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Border")) return;
        Destroy(other.gameObject);
        _health--;
        if (_health <= 0)
            _onDeathEvent?.Invoke();
        
        OnHealthChanged?.Invoke(_health);
    }
}
