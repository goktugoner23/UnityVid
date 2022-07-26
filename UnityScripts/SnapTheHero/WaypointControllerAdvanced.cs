using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointControllerAdvanced : MonoBehaviour {

    public List<GameObject> waypoints = new List<GameObject>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //waypointe vardık demek
    private int lastWaypointIndex;
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 5.0f;
    private float xPos;

    void Start() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("waypoint")){
            waypoints.Add(obj);
        }
        lastWaypointIndex = waypoints.Count - 1; 
        targetWaypoint = waypoints[targetWaypointIndex].transform; //ilk hedef waypointi belirleme
    }
	
	
	void Update() {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position; //waypointe giden yön vektörü
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget); //waypoint ile player arasındaki rotation

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep); //player waypointe dönüyor

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //direction kontrolü
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //rotation kontrolü

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

	}

    //bir sonraki waypointe gitmek için gerekli fonk.
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if(currentDistance <= minDistance)
        {
            targetWaypointIndex++; //ulaşınca dizideki indexi büyüt
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if(targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0; //ilk waypointe geri dönmek için, BUNU KALDIRABİLİRİM
        }

        targetWaypoint = waypoints[targetWaypointIndex].transform; //sonraki waypointi belirle
    }
}