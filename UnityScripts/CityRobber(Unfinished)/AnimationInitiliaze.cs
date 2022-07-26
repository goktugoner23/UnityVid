using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInitiliaze : MonoBehaviour
{
    #region Fields
    [Header("Singleton")]
    public static AnimationInitiliaze Instance;

    [Header("Animations")]
    public Animator anim;
    private bool callOnce = false;
    #endregion

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void RunningAnimation()
    {
        if (!callOnce)
        {
            anim.SetTrigger("Run");
            callOnce = true;
        }
    }

    public void IdleAnimation()
    {
        if (callOnce)
        {
            anim.SetTrigger("Idle");
            callOnce = false;
        }
    }
}
