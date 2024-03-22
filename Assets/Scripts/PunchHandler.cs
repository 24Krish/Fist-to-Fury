using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHandler : MonoBehaviour
{
    public SphereCollider PunchCollider;
    public void EnablePunchCollider()
    {
        PunchCollider.enabled = true; 
    }

    public void DisablePunchCollider()
    {
        PunchCollider.enabled = false;
    }

    public void DisableIsBlocking() 
    {
        GetComponentInParent<BlockDetection>().IsBlocking = false;
    }

    public void EnableIsBlocking()
    {
        GetComponentInParent<BlockDetection>().IsBlocking = true;
    }

    public void EnableAllowInput()
    {
        GetComponentInParent<BlockDetection>().AllowInput = true;
    }
}
