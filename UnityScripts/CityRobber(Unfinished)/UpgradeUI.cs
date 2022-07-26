using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    #region Fields
    [Header("Variables")]
    [SerializeField]
    private float movementSpeed;
    private float movementSpeedCost;
    [SerializeField]
    private int moneyBagCapacity;
    private float moneyBagCapacityCost;
    [SerializeField]
    private float buyKeyCost;
    [Header("Components")]
    [SerializeField]
    private Button moveupButton;
    [SerializeField]
    private Button capacityButton;
    [SerializeField]
    private Button buykeyButton;

    #endregion

    #region Events
    private void Start()
    {
        movementSpeed = PlayerUpgrades.Instance.movementSpeed;
        movementSpeedCost = PlayerUpgrades.Instance.moneyStackAmount;
        moneyBagCapacity = PlayerUpgrades.Instance.playerMaxMoneyStackCount;
        moneyBagCapacityCost = 100;
        buyKeyCost = 100;

        //button texts
        moveupButton.GetComponentInChildren<TextMeshProUGUI>().text = movementSpeedCost.ToString();
        capacityButton.GetComponentInChildren<TextMeshProUGUI>().text = moneyBagCapacityCost.ToString();
        buykeyButton.GetComponentInChildren<TextMeshProUGUI>().text = buyKeyCost.ToString();
    }
    #endregion

    #region Functions
    public void MovementUpgrade() 
    {
        if (StackMoney.Instance.MoneyAmount >= movementSpeedCost)
        {
            movementSpeed += 0.1f;
            StackMoney.Instance.MoneyAmount -= movementSpeedCost;

            for (int i = 0; i < movementSpeedCost / PlayerUpgrades.Instance.moneyStackAmount; i++)
            {
                StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1].transform.position = transform.position;
                StackMoney.Instance.moneyStack.Remove(StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1]);
                StackMoney.stackY -= 0.1f;
            }
            movementSpeedCost += PlayerUpgrades.Instance.moneyStackAmount;
        }
        PlayerUpgrades.Instance.movementSpeed = movementSpeed;
        moveupButton.GetComponentInChildren<TextMeshProUGUI>().text = ((int)(movementSpeedCost)).ToString();
    }
    public void moneyBagUpgrade() 
    {
        if (StackMoney.Instance.MoneyAmount >= moneyBagCapacityCost)
        {
            moneyBagCapacity += 5;
            StackMoney.Instance.MoneyAmount -= moneyBagCapacityCost;

            for (int i = 0; i < moneyBagCapacityCost / PlayerUpgrades.Instance.moneyStackAmount; i++)
            {
                StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1].transform.position = transform.position;
                StackMoney.Instance.moneyStack.Remove(StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1]);
                StackMoney.stackY -= 0.1f;
            }
            moneyBagCapacityCost += PlayerUpgrades.Instance.moneyStackAmount;
        }
        PlayerUpgrades.Instance.playerMaxMoneyStackCount = moneyBagCapacity;
        capacityButton.GetComponentInChildren<TextMeshProUGUI>().text = ((int)(moneyBagCapacityCost)).ToString();
    }
    public void buyKeys() 
    {
        if (StackMoney.Instance.MoneyAmount >= buyKeyCost)
        {
            PlayerUpgrades.Instance.ownedKeyCount += 1;
            StackMoney.Instance.MoneyAmount -= buyKeyCost;

            for (int i = 0; i < buyKeyCost / PlayerUpgrades.Instance.moneyStackAmount; i++)
            {
                StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1].transform.position = transform.position;
                StackMoney.Instance.moneyStack.Remove(StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1]);
                StackMoney.stackY -= 0.1f;
            }
            buyKeyCost += PlayerUpgrades.Instance.moneyStackAmount;
        }
        buykeyButton.GetComponentInChildren<TextMeshProUGUI>().text = ((int)(buyKeyCost)).ToString();
    }

    public void Upgrade(float value, float cost, float val_increment) 
    {
        if (StackMoney.Instance.MoneyAmount >= cost)
        {
            value += val_increment;
            StackMoney.Instance.MoneyAmount -= cost;

            for (int i = 0; i < cost / PlayerUpgrades.Instance.moneyStackAmount; i++)
            {
                StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1].transform.position = transform.position;
                StackMoney.Instance.moneyStack.Remove(StackMoney.Instance.moneyStack[StackMoney.Instance.moneyStack.Count - 1]);
                StackMoney.stackY -= 0.1f;
            }
            cost += PlayerUpgrades.Instance.moneyStackAmount;
        }
    }
    #endregion
}
