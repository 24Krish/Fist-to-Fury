using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody rigidbodyFighter;
    private float horizontal;
    private bool IsMoving;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
         rigidbodyFighter = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxis("P1LSLR");
        vertical = Input.GetAxis("P1LSUD");
        Debug.Log(horizontal);
        if(horizontal < 0.1f && horizontal > -0.1f && vertical < 0.1f && vertical > -0.1f)
        {
            Debug.Log("Stopped");
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (IsMoving)
        {
            // Vector3 DesiredVelocity = Vector3.right * horizontal * MoveSpeed * vertical * Time.deltaTime;
            Vector3 DesiredVelocity = new Vector3(horizontal * Time.deltaTime * MoveSpeed, rigidbodyFighter.velocity.y, -vertical * MoveSpeed * Time.deltaTime);
            rigidbodyFighter.velocity = DesiredVelocity;
        }
        else
        {
            rigidbodyFighter.velocity = new Vector3(0, rigidbodyFighter.velocity.y, 0);
        }
        
    }
}
