using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NewtonGame.FirstMinigame
{
    public class SpeedController : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        
        [SerializeField] private float _maxAcceliration;
        
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        [SerializeField] private float _fading = 0.5f;

        [SerializeField] private UnityEvent _onSpeedChanged;

        private float _currentSpeedX;
        private float _currentAcceleration;

        public float CurrentSpeedX => _currentSpeedX;
        public Action<float> OnSpeedChanged;

        public void ChangeSpeed(Vector2 direction)
        {
            if (direction != Vector2.zero)
                _onSpeedChanged?.Invoke();
            var newAcceleration = direction.x * _acceleration * Time.deltaTime;
            _currentAcceleration += Mathf.Clamp(newAcceleration, -_maxAcceliration, _maxAcceliration);
        }

        private void Update()
        {
            if (_currentAcceleration < 0 && _currentSpeedX < 1) _currentAcceleration = 0;
            var newSpeedX = _currentSpeedX + _currentAcceleration ;
            _currentSpeedX = Math.Clamp(newSpeedX, _minSpeed, _maxSpeed);
            _currentAcceleration = Mathf.Lerp(_currentAcceleration, -_maxAcceliration, _fading * Time.deltaTime);
            
            OnSpeedChanged.Invoke(_currentSpeedX);
        }
    }
}
