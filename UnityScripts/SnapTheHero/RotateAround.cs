using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bağımsız rotation/tilt dengesini sağlamak için karakterin bağlı olduğu gameobjecti hareket ettiriyorum(move/rotation), fakat karakterin kendisini döndürüyorum(tilt). Uçarken döndüğü yere doğru hafif yatması için.
public class RotateAround : MonoBehaviour
{
    public static bool levelFinished = false; //level loader dan kontrol edilecekleri için static
    public static bool gameOver = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6)
        {
            //transform.RotateAround(target.transform.position, Vector3.forward, -45*Time.deltaTime); çalışmadı, sonraki scriptler için saklıyorum
            //xPos = transform.position.x; layere göre değil pozisyona göre rotate etmek için yazdım
            transform.Rotate(transform.forward, 20f, Space.World);
            //Debug.Log("sol");
        }
        else if (other.gameObject.layer == 7)
        {
            //transform.RotateAround(target.transform.position, Vector3.forward, 45*Time.deltaTime); çalışmadı, sonraki scriptler için saklıyorum
            //xPos = transform.position.x; layere göre değil pozisyona göre rotate etmek için yazdım
            transform.Rotate(transform.forward, -20f, Space.World);
            //Debug.Log("sağ");
        }else if (other.gameObject.layer == 8)
        {
            if (CheckLens.score <= 0) //score > 0 
            {
                gameOver = true;
            }else
            {
                levelFinished = true;
            }       
        }
    }
}
