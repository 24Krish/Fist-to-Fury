using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animation;

    public void IsWalkingTrue()
    {
        animation.SetBool("IsWalking", true);
    }

    public void IsWalkingFalse()
    {
        animation.SetBool("IsWalking", false);
    }

    public void Punch()
    {
        animation.SetTrigger("PunchTrigger");
    }
}
