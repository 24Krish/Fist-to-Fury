using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PunchHandler : MonoBehaviour
{
    public SphereCollider PunchCollider;
    public SphereCollider KickCollider;
    public GameObject ProjectilePrefab;
    public Transform handTransform;
    private PlayerNumber playerNumber;
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

    public void EnableKickCollider()
    {
        KickCollider.enabled = true;
    }

    public void DisableKickCollider()
    {
        KickCollider.enabled = false;
    }

    public void HandleThrowEvent()
    {
        GameObject SpawnedProjectile = Instantiate(ProjectilePrefab, handTransform.position, transform.parent.transform.rotation);
        SpawnedProjectile.GetComponent<ProjectileDamage>().playerNumber = playerNumber.AssignedPlayerNumber;
    }

    private void Start()
    {
        playerNumber = GetComponentInParent<PlayerNumber>();
    }
}
