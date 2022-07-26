using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform roadObj;
    public Transform buildObj;
    public GameObject cay, komur, makarna;
    //public gameobject lightball;
    private Vector3 nextRoadSpawn, nextBuildingSpawn;

    void Start()
    {
        nextRoadSpawn.z = 75;
        nextBuildingSpawn.z = 154;
        nextBuildingSpawn.x = -27.5f;
        StartCoroutine(spawnRoad());
        StartCoroutine(spawnBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnRoad()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(roadObj, nextRoadSpawn, roadObj.rotation);
        nextRoadSpawn.z += 5;
        Instantiate(roadObj, nextRoadSpawn, roadObj.rotation);
        nextRoadSpawn.z += 5;
        StartCoroutine(spawnRoad());
    }

    IEnumerator spawnBuilding()
    {
        yield return new WaitForSeconds(6f);
        Instantiate(buildObj, nextBuildingSpawn, Quaternion.Euler(0,180,0));
        nextBuildingSpawn.z += 96;
        StartCoroutine(spawnBuilding());
    }
}
