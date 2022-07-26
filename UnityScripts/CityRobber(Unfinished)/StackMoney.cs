using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class StackMoney : MonoBehaviour
{
    #region Fields
    [Header("Singleton")]
    public static StackMoney Instance;
    [Header("Components")]
    public GameObject bag;
    public List<GameObject> moneyStack = new List<GameObject>();
    public List<GameObject> garbageMoneyCollector = new List<GameObject>();
    [Header("Variables")]
    public static float stackY = 0.1f;
    public float MoneyAmount; //amount that player has
    #endregion
    #region Events
    private void Awake()
    {
        if (Instance != this)
        {
            Instance = this;
        }
        else
        { 
            Destroy(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IInteractible>().Interact();
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<IInteractible>().UnInteract();
    }
    #endregion
    #region Functions
    #endregion
}
