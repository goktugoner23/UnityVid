using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_Diamonds : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    public GameObject diamondPiece1;
    public GameObject diamondPiece2;
    public GameObject diamondPiece3;
    public GameObject diamondPiece4;
    public GameObject diamondPiece5;
    public GameObject diamondPiece6;
    public GameObject diamondPiece7;
    public GameObject diamondPiece8;
    public bool passed;
    #endregion
    #region Events
    #endregion
    #region Functions
    public void CheckIfPassed()
    {
        if (diamondPiece1.GetComponent<ItemDragHandler1>().placed && diamondPiece2.GetComponent<ItemDragHandler1>().placed &&
            diamondPiece3.GetComponent<ItemDragHandler1>().placed && diamondPiece4.GetComponent<ItemDragHandler1>().placed &&
            diamondPiece5.GetComponent<ItemDragHandler1>().placed && diamondPiece6.GetComponent<ItemDragHandler1>().placed &&
            diamondPiece7.GetComponent<ItemDragHandler1>().placed && diamondPiece8.GetComponent<ItemDragHandler1>().placed)
        {
            Debug.Log("minigame works");
            passed = true;
            gameObject.SetActive(false);
        }
        diamondPiece1.transform.localPosition = diamondPiece1.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece2.transform.localPosition = diamondPiece2.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece3.transform.localPosition = diamondPiece3.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece4.transform.localPosition = diamondPiece4.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece5.transform.localPosition = diamondPiece5.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece6.transform.localPosition = diamondPiece6.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece7.transform.localPosition = diamondPiece7.GetComponent<ItemDragHandler1>().objectStartPos;
        diamondPiece8.transform.localPosition = diamondPiece8.GetComponent<ItemDragHandler1>().objectStartPos;
    }
    #endregion
}
