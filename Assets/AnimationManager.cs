using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float UltimateAttackDuration;
    private float CurrentUltimateAttackDuration;
    public Animator animation;
    private bool IsInUltimateAttack;
    public PunchHandler punchHandler;

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
    public void Block()
    {
        animation.SetTrigger("Block");

    }

    public void Kick()
    {
        animation.SetTrigger("KickTrigger");

    }

    public void Throw()
    {
        animation.SetTrigger("ThrowTrigger");
    }

    public void UltimateAttack()
    {
        animation.SetBool("UltimateAttack", true);
        IsInUltimateAttack = true;
        CurrentUltimateAttackDuration = UltimateAttackDuration;
        punchHandler.EnableLeftFootCollider();
    }
    public void VictoryEmote()
    {
        animation.SetTrigger("VictoryTrigger");
    }
    private void Update()
    {
        if (IsInUltimateAttack)
        {
            CurrentUltimateAttackDuration -= Time.deltaTime;
            if (CurrentUltimateAttackDuration <= 0)
            {
                animation.SetBool("UltimateAttack", false);
                IsInUltimateAttack = false;
                punchHandler.DisableLeftFootCollider();
            }
        }
    }
}
