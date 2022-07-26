using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
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
            //gameObject.SetActive(false);
            //transform.localPosition = objectStartPos; //correct locks, deactivate the object and return it to its original Pos in case of playing again
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            transform.localPosition = objectTransform.localPosition;
            placed = true;
        }
        else 
        {
            transform.localPosition = objectStartPos; //localpos of key
        } 
    }

    #endregion

    #region Functions

    #endregion
}
