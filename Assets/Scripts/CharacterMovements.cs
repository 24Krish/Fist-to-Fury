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
        // Check each joystick axis for input
        /*for (int joystickNumber = 1; joystickNumber <= 1; joystickNumber++) // Assuming up to 4 joysticks for simplicity
        {
            string horizontalAxisName = "Horizontal" + joystickNumber; // Your axis names might differ
            string verticalAxisName = "Vertical" + joystickNumber; // Your axis names might differ

            float moveHorizontal = Input.GetAxis(horizontalAxisName);
            float moveVertical = Input.GetAxis(verticalAxisName);

            if (Mathf.Abs(moveHorizontal) > InputThreshold || Mathf.Abs(moveVertical) > InputThreshold)
            {
                // Log the joystick providing the input
                Debug.Log($"Movement detected on Joystick {joystickNumber}");
                // Optionally, get and log the name of the joystick
                string joystickName = GetJoystickName(joystickNumber);
                Debug.Log($"Joystick {joystickNumber} Name: {joystickName}");
                break; // Break after detecting input to avoid logging multiple joysticks if there's coincidental simultaneous input
            }
        }*/
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
