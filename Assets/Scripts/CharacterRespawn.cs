using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    public Transform RespawnPoint;
    public CombatManager combatManager;
    private void OnTriggerEnter(Collider other)
    {
        int playernumber = other.GetComponent<CharacterMovement>().PlayerNumber;
        if (playernumber == 1)
        {
            combatManager.RoundOver(2);
        }

        else
        {
            combatManager.RoundOver(1);
        }
        other.gameObject.transform.position = RespawnPoint.position;
    }
}
