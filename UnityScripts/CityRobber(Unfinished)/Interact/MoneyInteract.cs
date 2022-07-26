using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyInteract : MonoBehaviour, IInteractible
{
    [Header("Variables")]
    [SerializeField]
    private bool taken;
    private float moneyCDCounter;
    [SerializeField]
    private float moneyCD;
    [Header("Components")]
    public GameObject moneyPrefab;
    [SerializeField]
    private Vector3 moneyPos;
    private void Start()
    {
        moneyCDCounter = moneyCD;
        moneyPos = gameObject.transform.position;
    }
    private void Update()
    {
        Respawn();
    }
    public void Interact()
    {
        if (StackMoney.Instance.MoneyAmount < 100 * PlayerUpgrades.Instance.playerMaxMoneyStackCount) //default money stack * maxstack is the size of the bag
        {
            gameObject.GetComponent<Collider>().enabled = false;
            var bag = StackMoney.Instance.bag;
            gameObject.transform.DOJump(new Vector3(bag.transform.position.x, bag.transform.position.y + StackMoney.stackY, bag.transform.position.z), 1f, 1, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                gameObject.transform.SetParent(bag.transform);
                gameObject.transform.position = new Vector3(bag.transform.position.x, bag.transform.position.y + StackMoney.stackY, bag.transform.position.z);
                StackMoney.stackY += 0.1f;
                gameObject.transform.rotation = bag.transform.rotation;
                StackMoney.Instance.moneyStack.Add(gameObject);
                if (100 * PlayerUpgrades.Instance.playerMaxMoneyStackCount - StackMoney.Instance.MoneyAmount < PlayerUpgrades.Instance.moneyStackAmount) //if players exceed money lower than stack amount
                {
                    StackMoney.Instance.MoneyAmount += 100 * PlayerUpgrades.Instance.playerMaxMoneyStackCount - StackMoney.Instance.MoneyAmount;
                }else StackMoney.Instance.MoneyAmount += PlayerUpgrades.Instance.moneyStackAmount;
            });
            taken = true;
        }
    }
    public void UnInteract()
    {
    }
    private void Respawn()
    {
        if (taken)
        {
            moneyCDCounter -= Time.deltaTime;
            if (moneyCDCounter <= 0)
            {
                moneyCDCounter = moneyCD;
                taken = false;
                GameObject spawnedMoney = Instantiate(moneyPrefab, moneyPos, Quaternion.identity);
                spawnedMoney.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0);
                spawnedMoney.GetComponent<Collider>().enabled = true;
            }
        }
    }
}
