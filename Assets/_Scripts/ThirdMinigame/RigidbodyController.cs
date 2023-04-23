using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyController : MonoBehaviour
{ 
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _fadingSpeed;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        PlayerInput.Instance.OnAxisButtonPressed += AddVelocity;
    }
    

    public void AddVelocity(Vector2 direction, float customAcceleration )
    {
        var newXVelocity = Mathf.Clamp(_rigidbody.velocity.x + direction.x * (customAcceleration * Time.deltaTime),
            -_maxVelocity, _maxVelocity);
        var newVelocity = new Vector2(newXVelocity, 0);
        _rigidbody.velocity = newVelocity;
    }

    private void AddVelocity(Vector2 direction)
    {
        AddVelocity(direction, _acceleration);
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, _fadingSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        PlayerInput.Instance.OnAxisButtonPressed -= AddVelocity;
    }
}
