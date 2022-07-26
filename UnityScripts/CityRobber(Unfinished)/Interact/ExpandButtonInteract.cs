using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExpandButtonInteract : MonoBehaviour, IInteractible_Button
{
    [SerializeField]
    public int money2Unlock;
    public Transform areapos;
    public int receivedmoney;
    public GameObject unlockedCity;
    public BoxCollider invisibleWall;
    public bool cityUnlocked;
    public void Interact()
    {
        money2Unlock = 1000;
        int tempmoneyKeep = 0;
        if (StackMoney.Instance.MoneyAmount >= money2Unlock)
        {
            tempmoneyKeep = (int)(money2Unlock / PlayerUpgrades.Instance.moneyStackAmount + 1);
            int count = StackMoney.Instance.moneyStack.Count;
            //buying state, adjust later
            for (int i = 1; i < tempmoneyKeep; i++)
            {
                StackMoney.Instance.moneyStack[count - i].transform.DOJump(areapos.transform.position, 1f, 1, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    StackMoney.stackY -= 0.1f;
                    StackMoney.Instance.MoneyAmount -= PlayerUpgrades.Instance.moneyStackAmount;
                    receivedmoney += (int)(PlayerUpgrades.Instance.moneyStackAmount);
                });
                StackMoney.Instance.moneyStack[count - i].transform.position = areapos.transform.position;
                StackMoney.Instance.moneyStack[count - i].transform.SetParent(null);
                StackMoney.Instance.garbageMoneyCollector.Add(StackMoney.Instance.moneyStack[count - i]);
                StackMoney.Instance.moneyStack.Remove(StackMoney.Instance.moneyStack[count - i]);
                foreach (GameObject item in StackMoney.Instance.garbageMoneyCollector)
                {
                    Destroy(item);
                }
                Debug.Log("works");
                //yield return new WaitForSeconds(0.05f);
            }
            gameObject.SetActive(false);
            CheckWin();
        }
        //StartCoroutine(wait());
    }

    public void Closed()
    {
        //empty
    }

    public void CheckWin()
    {
        //unlock city
        unlockedCity.SetActive(true);
        invisibleWall.enabled = false;
        cityUnlocked = true;
    }
}

