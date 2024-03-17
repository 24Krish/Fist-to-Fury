using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    public int PlayerNumber;
    public bool IsBlocking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis($"Player {PlayerNumber} Block") >= 0.1f)
        {
            IsBlocking = true;
        }

        else
        {
            IsBlocking = false;
        }
    
    }
}
