using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject firepoint;
    void Update()
    {
        if (firepoint.GetComponent<ObjectThrow>().ammo_Cay == 0)
        {
            Debug.Log("Çay bitti!");//game over screen gelecek
            this.enabled = false;
        }else if (firepoint.GetComponent<ObjectThrow>().ammo_Makarna == 0)
        {
            Debug.Log("Makarna bitti!");
            this.enabled = false;
        }else if(firepoint.GetComponent<ObjectThrow>().ammo_Komur == 0)
        {
            Debug.Log("Kömür bitti!");
            this.enabled = false;
        }
        //else if (firepoint.GetComponent<ObjectThrow>().ammo_Lightball == 0)
        //{
        //    Debug.Log("Işıklı top bitti!");
        //    this.enabled = false;
        //}

        //GAMEOVER EKRANI VEYA SCORE SCREEN, DURUMA GÖRE
    }
}
