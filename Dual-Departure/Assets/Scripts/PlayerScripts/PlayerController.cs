using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerController : MonoBehaviour
{
    // Movement variables
    Vector3 Velocity;
    public float Speed = 5f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    bool isGrounded;

    public GameObject character;
    public CharacterController characterController;
    public List<BaseTool> toolList;
    public bool IsHuman;

    protected string HorizontalAxis = "Horizontal";
    protected string VerticalAxis = "Vertical";
    protected string Interact = "Interac;";


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //  HorizontalAxis = PlayerPrefs.GetString("HorizontalAxis", "Horizontal");
        //  HorizontalAxis = PlayerPrefs.GetString("VerticalAxis", "Vertical");

        if (IsHuman)
        {
            HorizontalAxis = "Horizontal";
            VerticalAxis = "Vertical";
            Interact = "Interact;";
        }
        else
        {
            HorizontalAxis = "2-Horizontal";
            VerticalAxis = "2-Vertical";
            Interact = "2-Interact;";
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxisRaw(HorizontalAxis);
        float moveVertical = Input.GetAxisRaw(VerticalAxis);
        Vector3 Movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        characterController.Move(Movement * Speed * Time.deltaTime);
        characterController.Move(Velocity  * Time.deltaTime);


        // Movement.x -= 90;

        transform.position += Movement * Speed * Time.deltaTime;
       // Debug.Log(transform.position);
        Velocity.y += gravity * Time.deltaTime;
        //transform.localRotation = Quaternion.LookRotation(Movement).normalized;

        if (Movement.magnitude > 0.1)
        {
            // Rotation
            Vector3 rotVector = new Vector3(Movement.x - 90, 0f, Movement.z);
            var RotationDriveMode = Quaternion.LookRotation(Movement);
            character.transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);

        }
    }

    private void FixedUpdate()
    {


    //    Vector3 Movement = new Vector3(moveHorizontal, 0, moveVertical);
    //    //  character.GetComponent<Rigidbody>().AddForce( Movement * Speed * Time.deltaTime);
    //    Vector3 charPos = character.GetComponent<Rigidbody>().transform.position;
    //    Vector3 target = charPos + Movement;
    //    character.GetComponent<Rigidbody>().MovePosition(Movement * Speed * Time.deltaTime);
    }

    public void PickUpTool(BaseTool tool)
    {
        toolList.Add(tool);
        if (tool is ActiveTool)
        {

        }
    }
    public bool HasTool(BaseTool tool)
    {
        foreach (var collectedTool in toolList)
        {
            if (collectedTool == tool)
            {
                return true;
            }
        }
        return false;
 
    }

}
