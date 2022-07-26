using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class RobInteract : MonoBehaviour, IInteractible
{
    #region Fields
    [Header("Components")]
    public Button robButton;
    public GameObject moneyPrefab;
    public GameObject minigame;
    [Header("Variables")]
    public int reqKeyCount;
    [SerializeField]
    private int hasMoneyStack;
    [SerializeField]
    private int moneyTaken;
    public float shopCD;
    public float shopCDCounter;
    public bool robbed;
    public int xGridMoney;
    public int zGridMoney;
    public Transform moneygridStart;
    private float stackheight = 0f;
    #endregion

    #region Events
    private void Start()
    {
        shopCDCounter = shopCD;
        robbed = false;
        moneyTaken = hasMoneyStack;
    }
    private void Update()
    {
        ShopCooldown();
        GetMoney();
       
    }
    #endregion
    #region Functions
    public void Interact()
    {
        robButton.gameObject.SetActive(true);
        robButton.GetComponentInChildren<TextMeshProUGUI>().text = "ROB: " + "<color=#F7EB21>"+reqKeyCount+" x</color>";
    }

    public void UnInteract()
    {
        robButton.gameObject.SetActive(false);
    }

    private void ShopCooldown() 
    {
        if (minigame.GetComponent<Minigame_KeyLocks>() != null)
        {
            if (minigame.GetComponent<Minigame_KeyLocks>().passed && robbed == false) //minigame pass check
            {
                robButton.interactable = false;
                robbed = true;
            }
            else if (robbed)
            {
                shopCDCounter -= Time.deltaTime;
                if (shopCDCounter <= 0)
                {
                    shopCDCounter = shopCD;
                    robButton.interactable = true;
                    robbed = false;
                    moneyTaken = hasMoneyStack;
                }
            }
        }else if (minigame.GetComponent<Minigame_Diamonds>() != null) 
        {
            if (minigame.GetComponent<Minigame_Diamonds>().passed && robbed == false) //minigame pass check
            {
                robButton.interactable = false;
                robbed = true;
            }
            else if (robbed)
            {
                shopCDCounter -= Time.deltaTime;
                if (shopCDCounter <= 0)
                {
                    shopCDCounter = shopCD;
                    robButton.interactable = true;
                    robbed = false;
                    moneyTaken = hasMoneyStack;
                }
            }
        }
    }

    private void GetMoney() 
    {
        if (minigame.GetComponent<Minigame_KeyLocks>() != null)
        {
            if (minigame.GetComponent<Minigame_KeyLocks>().passed && moneyTaken > 0) //minigame1pass || minigame2pass || minigame3pass
            {
                for (int i = 0; i < xGridMoney; i++)
                {
                    for (int j = 0; j < zGridMoney; j++)
                    {
                        GameObject spawnedObject = Instantiate(moneyPrefab,
                        transform.position, Quaternion.identity);
                        spawnedObject.GetComponent<Collider>().enabled = false;
                        spawnedObject.transform.DOJump(new Vector3(moneygridStart.position.x + i, moneygridStart.position.y + stackheight, moneygridStart.position.z - j), 1f, 1, 0.5f).OnComplete(() =>
                        {
                            moneyTaken--;
                            spawnedObject.GetComponent<Collider>().enabled = true;
                        });
                        IEnumerator JumpWait()
                        {
                            yield return new WaitForSeconds(0.5f);
                        }
                        StartCoroutine(JumpWait());
                    }
                }
                minigame.GetComponent<Minigame_KeyLocks>().passed = false;
            }
        }
        else if (minigame.GetComponent<Minigame_Diamonds>() != null) 
        {
            if (minigame.GetComponent<Minigame_Diamonds>().passed && moneyTaken > 0) //minigame1pass || minigame2pass || minigame3pass
            {
                for (int i = 0; i < xGridMoney; i++)
                {
                    for (int j = 0; j < zGridMoney; j++)
                    {
                        GameObject spawnedObject = Instantiate(moneyPrefab,
                        transform.position, Quaternion.identity);
                        spawnedObject.GetComponent<Collider>().enabled = false;
                        spawnedObject.transform.DOJump(new Vector3(moneygridStart.position.x + i, moneygridStart.position.y + stackheight, moneygridStart.position.z - j), 1f, 1, 0.5f).OnComplete(() =>
                        {
                            moneyTaken--;
                            spawnedObject.GetComponent<Collider>().enabled = true;
                        });
                        IEnumerator JumpWait()
                        {
                            yield return new WaitForSeconds(0.5f);
                        }
                        StartCoroutine(JumpWait());
                    }
                }
                minigame.GetComponent<Minigame_Diamonds>().passed = false;
            }
        }
    }
    #endregion
}
