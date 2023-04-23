using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selectable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _selectBorders;

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        _selectBorders.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _selectBorders.gameObject.SetActive(false);
    }
}
