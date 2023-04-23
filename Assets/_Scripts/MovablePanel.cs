using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MovablePanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform _showTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private UnityEvent _onPointerEnter;
    [SerializeField] private UnityEvent _onPointerExit;

    private Vector3 _defaultPosition;
    private bool _isShowed;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    void Update()
    {
        var movePoint = _isShowed ? _showTransform.position : _defaultPosition;
        transform.position = Vector3.MoveTowards(transform.position, movePoint, _moveSpeed * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isShowed = true;
        _onPointerEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isShowed = false;
        _onPointerExit?.Invoke();
    }
}
