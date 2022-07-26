using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    [Range(0, 300)]
    private float spinSpeed;

    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0f, 0f, Space.Self);
    }
}
