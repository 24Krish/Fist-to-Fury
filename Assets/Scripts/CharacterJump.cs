using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    Rigidbody rigidbodyFighter;
    private bool TryingToJump;
    public float JumpForce;
    private int JumpCount = 2;
    private int JumpCounter = 0;    
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyFighter = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump_P1"))
        {
            Debug.Log("Jump_P1");
            TryingToJump = true;
        }   
    }
    private void FixedUpdate()
    {
        if (TryingToJump && JumpCounter < JumpCount)
        {
           JumpCounter++;
           rigidbodyFighter.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
           TryingToJump=false;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            JumpCounter = 0;
        }
    }
}
