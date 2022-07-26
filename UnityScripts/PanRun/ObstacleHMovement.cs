using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleHMovement : MonoBehaviour
{
    [SerializeField]
    [Range(300, 1200)]
    private float spinSpeed;
    [SerializeField]
    private float tDistance;
    [SerializeField]
    private float tDuration = 1f;
    void Start()
    {
        if (gameObject.CompareTag("Obstacle_V"))
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z + tDistance), tDuration).SetLoops(50, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
    void Update()
    {
        if (gameObject.CompareTag("Obstacle_V"))
        {
            transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }
}
