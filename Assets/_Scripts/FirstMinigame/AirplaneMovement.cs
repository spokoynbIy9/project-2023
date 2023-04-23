using System;
using System.Collections;
using System.Collections.Generic;
using NewtonGame.FirstMinigame;
using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    [SerializeField] private SpeedController _speedController;
    [SerializeField] private float _positionChangeSpeed;

    private void Update()
    {
        var newPosition = new Vector2(-3 + _speedController.CurrentSpeedX/20, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, newPosition, _positionChangeSpeed*Time.deltaTime);
    }
}
