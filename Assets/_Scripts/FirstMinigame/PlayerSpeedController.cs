using System;
using System.Collections;
using System.Collections.Generic;
using NewtonGame.FirstMinigame;
using UnityEngine;

public class PlayerSpeedController : SpeedController
{
    private void Start()
    {
        PlayerInput.Instance.OnAxisButtonPressed += ChangeSpeed;
    }

    private void OnDestroy()
    {
        PlayerInput.Instance.OnAxisButtonPressed -= ChangeSpeed;
    }
}
