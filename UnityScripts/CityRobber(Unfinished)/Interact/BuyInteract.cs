using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyInteract : MonoBehaviour, IInteractible
{
    public static BuyInteract Instance;
    public GameObject buyButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    public void Interact()
    {   
        buyButton.SetActive(true);
        //buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy: 2000$";
    }

    public void UnInteract() 
    {
        buyButton.SetActive(false);
    }
}
