using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpandInteract : MonoBehaviour, IInteractible
{
    #region Fields
    [Header("Components")]
    public Button expandButton;
    #endregion

    #region Functions
    public void Interact()
    {
        expandButton.gameObject.SetActive(true);
        expandButton.GetComponentInChildren<TextMeshProUGUI>().text = "Expand: " + expandButton.GetComponent<ExpandButtonInteract>().money2Unlock;
        if (expandButton.GetComponent<ExpandButtonInteract>().cityUnlocked) 
        {
            expandButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unlocked!";
            expandButton.interactable = false;
        }
    }

    public void UnInteract()
    {
        expandButton.gameObject.SetActive(false);
        expandButton.GetComponentInChildren<TextMeshProUGUI>().text = "<text>";
    }
    #endregion
}

