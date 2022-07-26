using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject smokeEffect, flameEffect;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Dayi" && gameObject.tag == "Komur"){
            GameObject cloneffect = Instantiate(flameEffect);
            Instantiate(cloneffect, gameObject.transform.position, Quaternion.identity);
            Destroy(cloneffect, 2);
        }else if ((collision.gameObject.tag == "Dayi" || collision.gameObject.tag == "Fat") && gameObject.tag == "Makarna"){
            GameObject cloneffect = Instantiate(smokeEffect);
            Instantiate(cloneffect, gameObject.transform.position, Quaternion.identity);
            Destroy(cloneffect, 2);
        }
    }
}
