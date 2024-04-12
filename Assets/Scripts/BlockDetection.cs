using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    private PlayerNumber playerNumber;
    public bool IsBlocking;
    private AnimationManager animationManager;
    public bool AllowInput = true;
    // Start is called before the first frame update
    void Start()
    {
        playerNumber = GetComponent<PlayerNumber>();
        animationManager = GetComponent<AnimationManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatManager.IsGameOver)
        {
            return;
        }
        if (Input.GetAxis($"Player {playerNumber.AssignedPlayerNumber} Block") >= 0.1f && AllowInput)
        {
            animationManager.Block();
            AllowInput = false;
        }
    }
}
