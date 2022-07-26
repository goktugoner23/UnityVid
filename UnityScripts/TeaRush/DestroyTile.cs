using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject bus;
    public float destroyafter = 25;
    
    private void Start() {
        bus = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        if(bus.transform.position.z > gameObject.transform.position.z + 15f)
        Destroy(gameObject, destroyafter);
    }
}
