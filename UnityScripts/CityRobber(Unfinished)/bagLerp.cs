using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bagLerp : MonoBehaviour
{
    #region Fields
    public float movementDelay = 0.25f;
    #endregion

    #region Events
    private void Update()
    {
        
        
    }
    #endregion

    #region Functions
    private void moveBagContent() 
    {
        for (int i = 1; i < StackMoney.Instance.moneyStack.Count; i++)
        {
            Vector3 pos = StackMoney.Instance.moneyStack[i].transform.localPosition;
            pos.x = StackMoney.Instance.moneyStack[i - 1].transform.localPosition.x;
            StackMoney.Instance.moneyStack[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    private void moveOrigin() 
    {
        for (int i = 1; i < StackMoney.Instance.moneyStack.Count; i++)
        {
            Vector3 pos = StackMoney.Instance.moneyStack[i].transform.localPosition;
            pos.x = StackMoney.Instance.moneyStack[0].transform.localPosition.x;
            StackMoney.Instance.moneyStack[i].transform.DOLocalMove(pos, 0.7f);
        }
    }
    #endregion
}
