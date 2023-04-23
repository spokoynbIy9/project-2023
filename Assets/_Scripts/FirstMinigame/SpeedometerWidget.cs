using System;
using System.Collections;
using System.Collections.Generic;
using NewtonGame.FirstMinigame;
using UnityEngine;

public class SpeedometerWidget : MonoBehaviour
{
    [SerializeField] private Transform _spedometerArrow;
    [SerializeField] private SpeedController _speedController;

    private float _defaultRotation;

    private void Awake()
    {
        _defaultRotation = _spedometerArrow.transform.rotation.z;
        _speedController.OnSpeedChanged += UpdateArrowPosition;
    }

    private void UpdateArrowPosition(float speed)
    {
        _spedometerArrow.localEulerAngles = new Vector3(0,0,  _defaultRotation -   speed);
    }

    private void OnDestroy()
    {
        _speedController.OnSpeedChanged -= UpdateArrowPosition;
    }
}
