using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanSize : MonoBehaviour
{
    public GameObject tavaParent;
    private void Update()
    {
        if (SpeedUp.superboosted)
        {
            tavaParent.transform.DOScale(new Vector3(3, 3, 3), 0.5f).OnComplete(() => 
            {
                StartCoroutine(ResizeBack(5f));
                IEnumerator ResizeBack(float time)
                {
                    yield return new WaitForSeconds(time * 150 * Time.deltaTime);
                    tavaParent.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
                }
            });
        }
    }
}
