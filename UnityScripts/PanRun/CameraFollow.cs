using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(target);
    }

}