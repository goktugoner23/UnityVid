using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonInteract : MonoBehaviour, IInteractible_Button
{
    [SerializeField]
    public GameObject upgradeScreen;
    public void Interact() 
    {
        gameObject.SetActive(false);
        upgradeScreen.gameObject.SetActive(true);
    }

    public void Closed() 
    {
        upgradeScreen.gameObject.SetActive(false);
        States.Instance.state = GameStates.Idle; //back to idle
    }

    public void CheckWin() 
    {
        //empty
    }
}
