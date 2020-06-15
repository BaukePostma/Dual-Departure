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

    //Controls
    protected string HorizontalAxis = "Horizontal";
    protected string VerticalAxis = "Vertical";
    protected string Interact = "Interac;";

    //Interact
    private float interactCooldown = 0.5f;
    private float interactCooldownCounter;

    // Death & Restart
    private bool isDying;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //  HorizontalAxis = PlayerPrefs.GetString("HorizontalAxis", "Horizontal");
        //  HorizontalAxis = PlayerPrefs.GetString("VerticalAxis", "Vertical");

        if (IsHuman)
        {
            HorizontalAxis = "Horizontal";
            VerticalAxis = "Vertical";
            Interact = "Interact";
        }
        else
        {
            HorizontalAxis = "2-Horizontal";
            VerticalAxis = "2-Vertical";
            Interact = "2-Interact";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement logic , move this to a seperate class later
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
            //character.transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);
            transform.localRotation = Quaternion.LookRotation(Movement, Vector3.up);


        }

        // Interact logic
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("HIT");

            InteractUpdate(hit);
            HighlightUpdate(hit);

            // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
        }

        interactCooldownCounter += Time.deltaTime;

        //Death Logic
        if (isDying)
        {

            transform.Rotate(transform.position, 15);
        }
    }

    private void InteractUpdate(RaycastHit hit)
    {
        if (Input.GetAxisRaw(Interact) == 1)
        {
            //Debug.Log(Interact + " pressed.Time since last interact: " + interactCooldownCounter );
            if (interactCooldownCounter >= interactCooldown)
            {
                interactCooldownCounter = 0;
              //  Debug.Log("Interacting. Time since last interact: " + interactCooldownCounter);
                if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
                {
                    hit.collider.gameObject.GetComponent<IInteractable>().Interact(this.gameObject);
                }
            }
        }

        else
        {
            return;
        }
    }
    private void HighlightUpdate(RaycastHit hit)
    {
            
        if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
        {
            hit.collider.gameObject.GetComponent<IInteractable>().Highlight(this.gameObject);
        }
    }

    private RaycastHit CheckForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("HIT");

            // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
        }
        return hit;
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
    public void Kill()
    {
        isDying = true; 
    }

}
