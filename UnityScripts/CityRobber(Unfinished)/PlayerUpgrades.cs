using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    public static PlayerUpgrades Instance;
    [Header("Variables")]
    public float moneyStackAmount;
    public float movementSpeed;
    public float moneymultiplier;
    public int ownedKeyCount;
    public int playerMaxMoneyStackCount;
    #endregion
    #region Events
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        playerMaxMoneyStackCount = 20;
        moneyStackAmount = 100;
        movementSpeed = 4;
        ownedKeyCount = 0;
    }
    #endregion
}
