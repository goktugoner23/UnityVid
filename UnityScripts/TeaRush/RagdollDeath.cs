using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject fatObj;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    public CapsuleCollider mainCollider;

    private void Start() {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
    }

    private void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;

        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach(Collider coll in ragdollColliders)
        {
            coll.enabled = state;
        }

        animator.enabled = !state;
        mainCollider.enabled = !state;
        GetComponent<Rigidbody>().isKinematic = state;
    }

    private void Die()
    {
        ToggleRagdoll(true);
        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.AddExplosionForce(107f, transform.position + new Vector3(0.5f,0,0f), 3f, 0f, ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Cay")
        {
            Die();
            Debug.Log("die");
        }else if (collision.gameObject.tag == "Makarna")
        {
            Instantiate(fatObj, gameObject.transform.position, gameObject.transform.rotation);
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            Die();
        }else if (collision.gameObject.tag == "Komur")
        {
            Destroy(collision.gameObject);
            Die();
            Debug.Log("burn");
        }
        //else if (collision.gameObject.tag == "Lightball")
        //{
            //baska bir effect düşün
        //    Die();
        //    Debug.Log("lighten up");
        //}
    }
}
