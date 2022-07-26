using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTrack : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    public TextMeshProUGUI score;
    public TextMeshProUGUI keyCount;
    #endregion
    private void Update()
    {
        score.text = ((int)(StackMoney.Instance.MoneyAmount)).ToString() + " / " + (PlayerUpgrades.Instance.playerMaxMoneyStackCount * 100).ToString();
        keyCount.text = ": " + PlayerUpgrades.Instance.ownedKeyCount.ToString();
    }
}
