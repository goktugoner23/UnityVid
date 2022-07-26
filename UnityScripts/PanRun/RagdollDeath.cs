using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    public BoxCollider mainCollider;

    public static bool swingFromRight = true; //variable for hitting from left and right side respectively
    public static bool IScored = false;
    private int score = 0;

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
        if (gameObject.tag == "NPC")
        {
            ToggleRagdoll(true);
            if (swingFromRight)
            {
                foreach (Rigidbody rb in ragdollBodies)
                {
                    rb.AddExplosionForce(77f, transform.position + new Vector3(0.5f, 0, 0f), 3f, 0f, ForceMode.Impulse);
                }
            }
            else
            {
                foreach (Rigidbody rb in ragdollBodies)
                {
                    rb.AddExplosionForce(77f, transform.position - new Vector3(0.5f, 0, 0f), 3f, 0f, ForceMode.Impulse);
                }
            }
            swingFromRight = !swingFromRight;
            Destroy(this.gameObject, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "NPC")
        {
            if (gameObject.layer == 6)
            {
                score = 2;
            }
            else score = 1;
            Die();
            ScoreTrack.score += score; //add 1 or 2 to score according to npc type
            IScored = true;
        }
    }

}