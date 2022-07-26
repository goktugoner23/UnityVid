using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_KeyLocks : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField]
    public GameObject keyPink;
    [SerializeField]
    public GameObject keyGreen;
    [SerializeField]
    public GameObject keyBlue;
    [SerializeField]
    public GameObject keyOrange;
    public bool passed;
    #endregion
    #region Events
    #endregion
    #region Functions
    public void CheckIfPassed()
    {
        if (keyPink.GetComponent<ItemDragHandler>().placed && keyGreen.GetComponent<ItemDragHandler>().placed && keyBlue.GetComponent<ItemDragHandler>().placed && keyOrange.GetComponent<ItemDragHandler>().placed)
        {
            Debug.Log("minigame works");
            passed = true;
            gameObject.SetActive(false);
            keyPink.SetActive(true);
            keyGreen.SetActive(true);
            keyBlue.SetActive(true);
            keyOrange.SetActive(true);
        }
        keyPink.transform.localPosition = keyPink.GetComponent<ItemDragHandler>().objectStartPos;
        keyGreen.transform.localPosition = keyGreen.GetComponent<ItemDragHandler>().objectStartPos;
        keyBlue.transform.localPosition = keyBlue.GetComponent<ItemDragHandler>().objectStartPos;
        keyOrange.transform.localPosition = keyOrange.GetComponent<ItemDragHandler>().objectStartPos;
    }
    #endregion
}
