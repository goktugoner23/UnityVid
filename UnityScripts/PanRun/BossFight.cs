using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFight : MonoBehaviour
{
    public Animator anims;
    public Transform boss;
    public GameObject mainCam;   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Final")
        {
            Debug.Log("Final");
            anims.SetTrigger("BossHit");
            transform.DOMove(boss.transform.position, 1.5f).SetEase(Ease.Linear).OnComplete(() => 
            {
                mainCam.gameObject.GetComponent<CameraFollow>().target = boss;
                mainCam.gameObject.GetComponent<CameraFollow>().offset = new Vector3(17.38f, 9.24f, -15.31f);
            });
        }
    }
}
