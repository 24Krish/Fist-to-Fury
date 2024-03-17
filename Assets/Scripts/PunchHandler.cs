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
}
