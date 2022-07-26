using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject scoreEffect;
    [SerializeField]
    private GameObject scoreEffect2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            GameObject cloneffect = Instantiate(hitEffect);
            Instantiate(cloneffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 4, gameObject.transform.position.z), Quaternion.identity);
            Destroy(cloneffect, 1);

            if (gameObject.layer == 6) //npcboss score +2
            {
                GameObject cloneffect2 = Instantiate(scoreEffect2);
                Instantiate(cloneffect2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z), Quaternion.identity);
                Destroy(cloneffect2, 1);
            }
            else //npc score +1
            {
                GameObject cloneffect2 = Instantiate(scoreEffect);
                Instantiate(cloneffect2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z), Quaternion.identity);
                Destroy(cloneffect2, 1);
            }
        }
    }
}
