using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    public int PlayerNumber;
    public bool IsBlocking;
    private AnimationManager animationManager;
    public bool AllowInput = true;
    // Start is called before the first frame update
    void Start()
    {
        animationManager = GetComponent<AnimationManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis($"Player {PlayerNumber} Block") >= 0.1f && AllowInput)
        {
            animationManager.Block();
            AllowInput = false;
        }
    }
}
