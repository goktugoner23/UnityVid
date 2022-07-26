using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceType : MonoBehaviour
{
    private Animator npcAnim;
    [SerializeField]
    private string danceType;

    private void Start()
    {
        npcAnim = GetComponent<Animator>();
    }
    void Update()
    {
        if (npcAnim != null)
        {
            npcAnim.SetTrigger(danceType);
        }
    }

}
