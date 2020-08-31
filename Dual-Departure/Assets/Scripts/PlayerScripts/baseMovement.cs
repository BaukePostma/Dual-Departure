using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
  
    //public baseMovement(CharacterController player, string horizontal, string vertical, string interact)
    //{
    //    characterController = player;
    //    HorizontalAxis = horizontal;
    //    VerticalAxis = vertical;
    //    Interact = interact;
    //}

    void Start()
    {
        characterController = GetComponent<CharacterController>();
      //  characterController.detectCollisions = false;
    }

    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
  
    }

    public void MoveCharacter(float moveHorizontal, float moveVertical)
    {
        if (isDying)
        {
            // Do some dying things
            transform.Rotate(transform.position, 15);
           
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

            if (isGrounded && Velocity.y < 0)
            {
                Velocity.y = -2f;
            }
            Vector3 Movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;
            characterController.Move(Movement * Speed * Time.deltaTime);
            characterController.Move(Velocity * Time.deltaTime);

            // Movement.x -= 90;
            Velocity.y += gravity * Time.deltaTime;
            //transform.localRotation = Quaternion.LookRotation(Movement).normalized;
            if (Movement.magnitude > 0.1)
            {
                // Rotation
                Vector3 rotVector = new Vector3(Movement.x - 90, 0f, Movement.z);
                var RotationDriveMode = Quaternion.LookRotation(Movement);
                //character.transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);
                transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);
            }
        }
      
    }
    /// <summary>
    /// Called from the controller in order to stop movement
    /// </summary>
    public void StartDying()
    {
        isDying = true;
    }
}
