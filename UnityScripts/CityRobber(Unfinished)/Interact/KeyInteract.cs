using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour, IInteractible
{
    [SerializeField]
    private bool taken;
    private float keyCDCounter;
    [SerializeField]
    private float keyCD;
    private void Start()
    {
        keyCDCounter = keyCD;
    }
    private void Update()
    {
        Respawn();
    }
    public void Interact()
    {
        PlayerUpgrades.Instance.ownedKeyCount++;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        taken = true;
    }

    public void UnInteract() 
    {
    }

    private void Respawn() 
    {
        if (taken)
        {
            keyCDCounter -= Time.deltaTime;
            if (keyCDCounter <= 0)
            {
                keyCDCounter = keyCD;
                taken = false;
                gameObject.GetComponent<Collider>().enabled = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
