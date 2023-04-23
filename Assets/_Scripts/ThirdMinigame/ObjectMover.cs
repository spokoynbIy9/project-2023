using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }
}
