using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler1 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    #region Fields
    [Header("Components")]
    [SerializeField]
    private RectTransform objectTransform;
    [Header("Variables")]
    public Vector3 objectStartPos;
    public bool placed;
    #endregion

    #region Events
    private void Awake()
    {
        objectStartPos = transform.localPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {  
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(objectTransform, Input.mousePosition))
        {
            transform.localPosition = objectTransform.localPosition; //correct locks, deactivate the object and return it to its original Pos in case of playing again
            placed = true;
        }
        else 
        {
            transform.localPosition = objectStartPos; //localpos of key
            placed = false;
        }
    }

    #endregion

    #region Functions

    #endregion
}
