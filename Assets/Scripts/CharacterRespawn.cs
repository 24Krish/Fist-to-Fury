using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    public Transform RespawnPoint;
    public CombatManager combatManager;
    private void OnTriggerEnter(Collider other)
    {
        combatManager.RoundOver(other.gameObject);
        other.gameObject.transform.position = RespawnPoint.position;
    }
}
