using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{
    public GameObject gameFlow;
    private GameObject throwPrefab;
    private int prefabIndex;
    public Transform shootPoint;
    public Transform contactPoint;

    public int ammo_Cay = 100;
    public int ammo_Makarna = 200;
    public int ammo_Komur = 50;
    //public int ammo_Lightball = 100;

    void Start()
    {
        throwPrefab = gameFlow.GetComponent<GameFlow>().makarna;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //elini ekrandan çekince ateş etmeli, basılı tutarsa force u arttırmak gibi bir planım var
        {
            LaunchProjectile();
        }
    }
    void LaunchProjectile()
    {
        if (throwPrefab.gameObject.tag == "Cay" && ammo_Cay > 0)
        {
            Vector3 Vo = CalculateVelocity(contactPoint.position, shootPoint.position, 0.8f);
            GameObject obj = Instantiate(throwPrefab, shootPoint.position, throwPrefab.transform.rotation); //firepointin rotationını düzelttim unityden
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vo, ForceMode.Impulse);
            ammo_Cay -= 1;
            Destroy(obj, 6);
        }
        else if (throwPrefab.gameObject.tag == "Makarna" && ammo_Makarna > 0) //Makarna daha hafif
        {
            Vector3 Vo = CalculateVelocity(contactPoint.position, shootPoint.position, 0.5f);
            GameObject obj = Instantiate(throwPrefab, shootPoint.position, throwPrefab.transform.rotation); //firepointin rotationını düzelttim unityden
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vo, ForceMode.Impulse);
            ammo_Makarna -= 1;
            Destroy(obj, 6);
        }
        else if (throwPrefab.gameObject.tag == "Komur" && ammo_Komur > 0) //Komur daha ağır
        {
            Vector3 Vo = CalculateVelocity(contactPoint.position, shootPoint.position, 1f);
            GameObject obj = Instantiate(throwPrefab, shootPoint.position, throwPrefab.transform.rotation); //firepointin rotationını düzelttim unityden
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vo, ForceMode.Impulse);
            ammo_Komur -= 1;
            Destroy(obj, 6);
        }
        //else if (throwPrefab.gameObject.tag == "Lightball" && ammo_Lightball > 0) //Buna bir özellik eklenmeli
        //{
        //    Vector3 Vo = CalculateVelocity(contactPoint.position, shootPoint.position, 0.3f);
        //    GameObject obj = Instantiate(throwPrefab, shootPoint.position, throwPrefab.transform.rotation); //firepointin rotationını düzelttim unityden
        //    Rigidbody rb = obj.GetComponent<Rigidbody>();
        //    rb.AddForce(Vo, ForceMode.Impulse);
        //    ammo_Lightball -= 1;
        //    Destroy(obj,6);
        //}
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Fy = distance.y;
        float Fxz = distanceXZ.magnitude;

        float Vxz = Fxz / time; //yatay düzlem
        float Vy = Fy / time + 0.7f * Mathf.Abs(Physics.gravity.y) * time; //yükseklik

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
