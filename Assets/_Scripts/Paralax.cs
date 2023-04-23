using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Vector3 _movePoint;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            _movePoint, 
            _speed * Time.deltaTime);
        if (transform.position == _movePoint)
            transform.position = _startPosition;

    }
}
