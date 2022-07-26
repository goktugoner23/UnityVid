using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeInteract : MonoBehaviour, IInteractible
{
    #region Fields
    [Header("Components")]
    public Button upgradeButton;
    #endregion

    #region Functions
    public void Interact()
    {
        upgradeButton.gameObject.SetActive(true);
        upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade";
    }

    public void UnInteract()
    {
        upgradeButton.gameObject.SetActive(false);
    }
    #endregion
}
