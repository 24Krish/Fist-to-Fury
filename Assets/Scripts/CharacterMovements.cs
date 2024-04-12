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
    private float InputThreshold = 0.1f;
    private AnimationManager animationmanager;
    private PlayerNumber playerNumber;
    private BlockDetection Block;
    // Start is called before the first frame update
    void Start()
    {
        animationmanager = GetComponent<AnimationManager>();    
         rigidbodyFighter = GetComponent<Rigidbody>();
        Block = GetComponent<BlockDetection>();
        playerNumber = GetComponent<PlayerNumber>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatManager.IsGameOver)
        {
            return;
        }
        horizontal = Input.GetAxis("Horizontal" + playerNumber.AssignedPlayerNumber);
        vertical = Input.GetAxis("Vertical" + playerNumber.AssignedPlayerNumber);
        // Debug.Log(horizontal);
        if (horizontal < 0.1f && horizontal > -0.1f && vertical < 0.1f && vertical > -0.1f)
        {
            // Debug.Log("Stopped");
            IsMoving = false;
            animationmanager.IsWalkingFalse();
        }
        else
        {
            Vector3 DesiredVelocity = new Vector3(horizontal, 0, -vertical);
            transform.rotation = Quaternion.LookRotation(DesiredVelocity);
            IsMoving = true;
            animationmanager.IsWalkingTrue();
        }
    }

    string GetJoystickName(int joystickNumber)
    {
        string[] joystickNames = Input.GetJoystickNames();
        if (joystickNumber <= joystickNames.Length && !string.IsNullOrEmpty(joystickNames[joystickNumber - 1]))
        {
            return joystickNames[joystickNumber - 1];
        }
        return "Unknown";
    }
    private void FixedUpdate()
    {
        if (IsMoving && !Block.IsBlocking)
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
