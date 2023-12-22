using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseoverChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool Moused = false;

    public void OnMouseEnter()
    {
        Moused = true;
    }

    public void OnMouseExit()
    {
        Moused = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Moused = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Moused = false;
    }
}
