using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private AnimationManager animationmanager;
    public int PlayerNumber;
    public BlockDetection Block;
    // Start is called before the first frame update
    void Start()
    {
        animationmanager = GetComponent<AnimationManager>();
        Block = GetComponent<BlockDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis($"P{PlayerNumber}A") >= 0.1f && !Block.IsBlocking)
        {
            animationmanager.Punch();
        }   
    }
}
