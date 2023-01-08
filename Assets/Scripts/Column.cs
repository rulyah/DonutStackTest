using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Column : MonoBehaviour, IPointerDownHandler
{
    public static event Action<int> onColumnClick; 
    
    private void Click()
    {
        onColumnClick?.Invoke((int)transform.position.x);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click();
    }
}