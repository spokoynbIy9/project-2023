using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Qte : MonoBehaviour
{
    [SerializeField] private List<Image> _bars;
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent _onSuccess;
    [SerializeField] private UnityEvent _onFail;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _onSuccess?.Invoke();

        foreach (var bar in _bars)
        {
            bar.fillAmount += _speed * Time.deltaTime;
            if (bar.fillAmount >= 0.99f)
            {
                _onFail?.Invoke();
                break;
            }
        }


    }
}
