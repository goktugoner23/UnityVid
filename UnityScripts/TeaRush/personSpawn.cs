using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personSpawn : MonoBehaviour
{
    public Transform personObj;
    private Vector3 nextPersonSpawn;
    private int randX;

    void Start()
    {
        nextPersonSpawn.z = 70;
        StartCoroutine(spawnPeople());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnPeople()
    {
        yield return new WaitForSeconds(0.8f);
        randX = Random.Range(-13,-19);
        nextPersonSpawn.y = 0f;
        nextPersonSpawn.x = randX;
        Instantiate(personObj, nextPersonSpawn, personObj.rotation);
        nextPersonSpawn.z += 10;
        StartCoroutine(spawnPeople());
    }
}
