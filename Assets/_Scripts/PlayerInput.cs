using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //TODO: поменять название поля
    public Action<Vector2> OnAxisButtonPressed;

    public static PlayerInput Instance;

    
    // Это подобие синглтона, он является антипатерном, но для прототипа сойдет
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        var input = new Vector2(xInput, 0);
        
        
        OnAxisButtonPressed?.Invoke(input);
    }
}
