using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private AnimationManager animationmanager;
    // Start is called before the first frame update
    void Start()
    {
        animationmanager = GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("P1A") >= 0.1f)
        {
            animationmanager.Punch();
        }   
    }
}
