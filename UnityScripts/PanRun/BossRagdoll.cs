using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossRagdoll : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    [Header("Components")]
    [SerializeField] private Transform _boss;
    [SerializeField] private Transform[] scorePositions;

    [Header("Variables")]
    private static float lastMass = 1;
    public static int scoreMultiplier;

    public BoxCollider mainCollider;
    private bool isRotate = false;


    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
    }

    private void Update()
    {
        RotateBoss(_boss);
    }
    private void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider coll in ragdollColliders)
        {
            coll.enabled = state;
        }

        animator.enabled = !state;
        mainCollider.enabled = !state;
        GetComponent<Rigidbody>().isKinematic = state;
    }

    private bool inRange(int from, int to)
    {
        return ScoreTrack.score >= from && ScoreTrack.score < to;
    }
    private void JumpToScore(Transform[] jumpPoint, Transform boss)
    {
        //adjust boss fall positions according to score
        for (int i = 0; i < 8; i++) 
        {
            if (inRange(5 * i, 5 * i + 5))
            {
                boss.transform.DOJump(jumpPoint[i].transform.position, 30f, 1, 1.4f + (i * 0.2f)).SetEase(Ease.Linear).OnComplete(() =>
                {
                    foreach (Rigidbody _rigids in ragdollBodies)
                    {
                        _rigids.useGravity = true;
                        _rigids.mass = lastMass;
                    }
                    isRotate = false;
                    scoreMultiplier = i + 1;
                    LevelTracker.levelPassed = true;
                });
            }
            else if (ScoreTrack.score >= 45) 
            {
                boss.transform.DOJump(jumpPoint[i + 1].transform.position, 30f, 1, 3).SetEase(Ease.Linear).OnComplete(() =>
                {
                    foreach (Rigidbody _rigids in ragdollBodies)
                    {
                        _rigids.useGravity = true;
                        _rigids.mass = lastMass;
                    }
                    isRotate = false;
                    scoreMultiplier = i + 1;
                    LevelTracker.levelPassed = true;
                });
            }
        }
    }

    private void AdjustMassesBeforePunch()
    {
        foreach (Rigidbody rigid in ragdollBodies)
        {
            rigid.mass = 0;
            rigid.useGravity = false;
        }
    }

    private void PunchBoss(float punchForce)
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.AddForce(Vector3.forward * punchForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    private void RotateBoss(Transform boss) 
    {
        if (isRotate) 
        {
            boss.transform.Rotate(new Vector3(200,20,0) * Time.deltaTime, Space.Self);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isRotate = true;
        ToggleRagdoll(true);
        PunchBoss(10);
        AdjustMassesBeforePunch();
        JumpToScore(scorePositions, _boss);
        LevelTracker.levelPassed = true;
    }
}
