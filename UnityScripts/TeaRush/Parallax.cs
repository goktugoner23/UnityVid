using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.z;
        length = GetComponent<SpriteRenderer>().bounds.size.z;
    }

    void FixedUpdate()
    {
        float temp = cam.transform.position.z * (1-parallaxEffect);
        float dist = (cam.transform.position.z * parallaxEffect);
        transform.position = new Vector3(transform.position.x, transform.position.y, startpos + dist);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
