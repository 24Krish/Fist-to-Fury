using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private AnimationManager animationmanager;
    private PlayerNumber playerNumber;
    private BlockDetection Block;
    // Start is called before the first frame update
    void Start()
    {
        animationmanager = GetComponent<AnimationManager>();
        Block = GetComponent<BlockDetection>();
        playerNumber = GetComponent<PlayerNumber>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis($"P{playerNumber.AssignedPlayerNumber}A") >= 0.1f && !Block.IsBlocking)
        {
            animationmanager.Punch();
        }
        
        else if(Input.GetButtonDown($"P{playerNumber.AssignedPlayerNumber}K") && !Block.IsBlocking)
        {
            animationmanager.Kick();
        }

        else if(Input.GetButtonDown($"P{playerNumber.AssignedPlayerNumber}T") && !Block.IsBlocking)
        {
            animationmanager.Throw();
        }

        else if (Input.GetButtonDown($"P{playerNumber.AssignedPlayerNumber}U") && !Block.IsBlocking)
        {
            animationmanager.UltimateAttack();
        }
    }
}
