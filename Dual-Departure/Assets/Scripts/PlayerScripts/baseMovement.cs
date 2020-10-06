using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for character movement. Messy code, but needed so that the neural network can fire the same events as a human
/// </summary>
public class baseMovement : MonoBehaviour
{
    //Controls
    public string HorizontalAxis;
    public string VerticalAxis;
    //public string Interact;

    // Movement variables
    Vector3 Velocity;
    public float Speed = 5f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    bool isGrounded;
    public bool isDying = false;
  
    protected CharacterController characterController;
  
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Gets called every frame. Determines how much a character should move this framne 
    /// </summary>
    /// <param name="moveHorizontal"></param>
    /// <param name="moveVertical"></param>
    public void MoveCharacter(float moveHorizontal, float moveVertical)
    {
        if (isDying)
        {
            // Do some silly dying things
            transform.Rotate(transform.position, 15);
        }
        else
        {
            // Calculate falling 
            isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
            if (isGrounded && Velocity.y < 0)
            {
                Velocity.y = -2f;
            }
            Vector3 Movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
            characterController.Move(Movement * Speed * Time.deltaTime);
            characterController.Move(Velocity * Time.deltaTime);
            Velocity.y += gravity * Time.deltaTime;

            // Charactermodel rotation
            if (Movement.magnitude > 0.1)
            {
                Vector3 rotVector = new Vector3(Movement.x - 90, 0f, Movement.z);
                var RotationDriveMode = Quaternion.LookRotation(Movement);
                transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);
            }
        }
      
    }
    /// <summary>
    /// Called from the controller in order to stop movement while the level is ending
    /// </summary>
    public void StartDying()
    {
        isDying = true;
    }
}
