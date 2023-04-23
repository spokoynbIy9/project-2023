using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _windPower;
    [SerializeField] private float _windAffectionSeconds;

    [SerializeField] private ObjectsSpawner _rightWindParticles;
    [SerializeField] private ObjectsSpawner _leftWindParticles;
    [SerializeField] private RigidbodyController _playerController;
    
    private float _timeDelta;
    private bool _isActive;

    private Vector2 _direction = Vector2.left;

    public void Activate()
    {
        StopParticles();
        _timeDelta = 0;
        _isActive = true;
        var randomInt = Random.Range(0, 2);
        
        var direction = randomInt == 0 ? Direction.Left : Direction.Right;
        var vectorDirection = direction == Direction.Left ? Vector2.left : Vector2.right;
        
        var particlesSpawner = direction == Direction.Left ?  _rightWindParticles : _leftWindParticles;
        particlesSpawner.StartSpawn();
        _direction = vectorDirection;

    }

    private void Update()
    {
        if (_isActive)
        {
            _playerController.AddVelocity(_direction, _windPower);
            
            _timeDelta += Time.deltaTime;
            if (_timeDelta >= _windAffectionSeconds)
            {
                StopParticles();
                _isActive = false;
                _timeDelta = 0;
            }
        }
    }

    private void StopParticles()
    {
        _leftWindParticles.StopSpawn();
        _rightWindParticles.StopSpawn();
    }
}

public enum Direction
{
    Left,
    Right
}