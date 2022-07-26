using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField]
    private GameObject speedEffect;
    [SerializeField]
    private Animator anim;
    public ParticleSystem speedline;

    public static bool boosted = false;
    public static bool superboosted = false;

    private void Update()
    {
        StartCoroutine(CheckBoost());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Speedpad") 
        {
            boosted = true;
            Debug.Log("boosted");
        }
    }
    private void Boost()
    {
        if (boosted) 
        {
            PlayerMovement.speed = 16f;
            anim.speed = 3f;
            speedline.Play();
        }
        boosted = false;
    }

    private void SuperBoost() 
    {
        if (superboosted) 
        {
            PlayerMovement.speed = 20f;
            anim.speed = 4f;
            speedline.Play();
        }
        superboosted = false;
    }

    IEnumerator CheckBoost() 
    {
        while (boosted == true || superboosted == true) 
        {
            Boost();
            
            SuperBoost();
            
        }
        yield return new WaitForSeconds(0.1f);
    }

}
