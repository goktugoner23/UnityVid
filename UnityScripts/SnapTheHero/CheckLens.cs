using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLens : MonoBehaviour
{
    [SerializeField]
    private GameObject camflash, capturedPrefab, greatPrefab, awesomePrefab, perfectPrefab; //kamera flashı ve foto çekince çıkacak olan yazılar
    private GameObject clone_camFlash;
    private GameObject clone_capturedPrefab;
    private GameObject clone_greatPrefab;
    private GameObject clone_awesomePrefab;
    private GameObject clone_perfectPrefab;
    public Transform target;
    public GameObject targetRenderer;
    public Camera cam;
    public static int score = 0;
    private int comboCounter = 0;

//burada 2 sn de bir foto çekmek istiyoruz. objektifin ve karakterin piksel cinsinden değerlerini alıp bu değerler kesiştikleri zaman foto çekmesini söyleyeceğiz. flash 0.5 saniyeliğine ekranda gözüküp kaybolacak.
 void Start() {
     StartCoroutine(Snapped());
 }

 private IEnumerator Snapped()
 {
    while (true){
    yield return new WaitForSeconds(2f);
    clone_camFlash = Instantiate(camflash, transform.position, Quaternion.Euler(0,-90,0)); //prefabin default rotationını ayarlamayı unuttum o yüzden burda düzelttim.
    clone_camFlash.transform.parent = this.transform;
    
    if (checkSnap())
    {
        Debug.Log("photo taken");
        if (comboCounter == 0)
        {
            clone_capturedPrefab = Instantiate(capturedPrefab, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0,-90,0)); //yazının objektifin biraz üstünde çıkması lazım.
            clone_capturedPrefab.transform.parent = this.transform;
            comboCounter ++;
            score++;
        }else if (comboCounter == 1)
        {
            clone_greatPrefab = Instantiate(greatPrefab, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0,-90,0)); 
            clone_greatPrefab.transform.parent = this.transform;
            comboCounter ++;
            score += 5;
        }else if (comboCounter == 2)
        {
            clone_awesomePrefab = Instantiate(awesomePrefab, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0,-90,0)); 
            clone_awesomePrefab.transform.parent = this.transform;
            comboCounter ++;
            score += 10;
        }else if (comboCounter >= 3)
        {
            clone_perfectPrefab = Instantiate(perfectPrefab, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler(0,-90,0)); 
            clone_perfectPrefab.transform.parent = this.transform;
            comboCounter ++;
            score += 20;
        }
        //score ++;
    }else comboCounter = 0; //foto çekemediğinde combo counterı 0 yapıyorum ki başa dönsün.
    yield return new WaitForSeconds(0.5f);
    Destroy(clone_camFlash);
    if (clone_capturedPrefab != null) Destroy(clone_capturedPrefab); //garbage cleaning. objeler null değilse destroy ediyorum yer kaplamasın diye.
    if (clone_greatPrefab != null) Destroy(clone_greatPrefab);
    if (clone_awesomePrefab != null) Destroy(clone_awesomePrefab);
    if (clone_perfectPrefab != null) Destroy(clone_perfectPrefab); 
    }
 }

private bool checkSnap()
{
    float targetDiameter = target.transform.localScale.z; //köşegen uzunluğu fazla geldiği için yatay uzunluğu alıyorum.
    float targetDistance = Mathf.Abs(target.transform.position.x - cam.transform.position.x); //kameraya olan uzaklık
    float lensDiameter = 0.8f; //sabit olduğu için direkt yazdım. lens distance da 4.57f.

    float target2pixel = DistanceAndDiameterToPixelSize(targetDistance, targetDiameter); //target ın piksel uzunluğu
    float lens2pixel = DistanceAndDiameterToPixelSize(4.57f, lensDiameter);    //objektifin piksel uzunluğu

    Vector3 screenPos = cam.WorldToScreenPoint(target.position);
    Vector3 camPos = cam.WorldToScreenPoint(transform.position);

    //uzunluk kontrol için yazdığım debug.log lar
    
    //Debug.Log("target is " + screenPos.x + " pixels from the left");
    //Debug.Log("target is " + screenPos.y + " pixels from the up");
    //Debug.Log("camera is " + camPos.x + " pixels from the left");
    //Debug.Log("camera is " + camPos.y + " pixels from the up");
    //Debug.Log("objective is " + lens2pixel + "pixels wide");
    //Debug.Log("supes is " + target2pixel + "pixels wide");

    //kahramanın pixel uzunluğunu bulup kameranın pixel konumunun içinde mi diye bakıcan

    if (screenPos.x + target2pixel/2 < camPos.x + lens2pixel/2 && screenPos.x - target2pixel/2 > camPos.x - lens2pixel/2) //objektif ve targetın piksel boyutları birbirini kapsıyor mu diye bakıyorum. bir de y ekseni için bakıcaz ve X x Y kartezyen koordinatında aynı kümedeyse target objektifin içinde diyebiliriz.
    {   
        if (screenPos.y + target2pixel/2 < camPos.y + lens2pixel/2 && screenPos.y - target2pixel/2 > camPos.y - lens2pixel/2)
        {
            return true;
            //SCORE 100
            //AWESOME SUPER
        }
    }
    return false;
}

//uzaklık ve köşegeni verilen objenin piksel cinsinden uzunluğunu bulan eşitlik.
float DistanceAndDiameterToPixelSize(float distance, float diameter){
       
    float pixelSize = (diameter * Mathf.Rad2Deg * Screen.height) / (distance * Camera.main.fieldOfView);
    return pixelSize;
}

}
