using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerController : MonoBehaviour
{
    private GameState state;

    // Movement variables
    public Transform groundcheck;
    public LayerMask groundMask;

    //public GameObject character;
    //public CharacterController characterController;
    //Tools
    public List<BaseTool> toolList;
    private ActiveTool activeTool;
    public bool IsHumanChracter;
    private GameObject objToolList;
    private float toolCountdown = 0.5f;
    private float toolCountdownCounter;

    //AI TEST
    public bool IsControlledByAI;

    //Controls
    protected string HorizontalAxis;// = "Horizontal";
    protected string VerticalAxis;// = "Vertical";
    protected string Interact; //= "Interac;";
    protected string UseTool; //= "Interac;";

    private baseMovement PlayerMovement;

    //Interact
    private const float interactCooldown = 0.5f;
    private float interactCooldownCounter;

    // Death & Restart
    private bool isDying;
   // private LevelLoader loader;
    void Start()
    {
        //loader

        SetPlayerControls();
        state = GameState.Instance;
        if (IsControlledByAI)
        {
            // Load brain or something
            PlayerMovement = gameObject.AddComponent<RobotMovement>();
        }
        else
        {
            SetPlayerControls();
            PlayerMovement = gameObject.AddComponent<HumanMovement>();
        }
       
        

        // Initialise controls

        PlayerMovement.groundcheck = groundcheck;
        PlayerMovement.groundMask = groundMask;
        PlayerMovement.HorizontalAxis = HorizontalAxis;
        PlayerMovement.VerticalAxis = VerticalAxis;
       // PlayerMovement.Interact = Interact;
        //PlayerMovement.UseTool = UseTool;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5)
        {
            Kill();
        }
        // Movement logic , move this to a seperate class later

        // PlayerMovement.Move();

        // Interact logic
        CheckForObject(Input.GetAxisRaw(Interact));

        if (Input.GetAxisRaw(UseTool) == 1 && activeTool != null && toolCountdownCounter >= toolCountdown)
        {
            toolCountdownCounter = 0;
            UseActiveTool();
        }

        toolCountdownCounter += Time.deltaTime;
    }

    private void InteractUpdate(RaycastHit hit)
    {

        //Debug.Log(Interact + " pressed.Time since last interact: " + interactCooldownCounter );
        if (interactCooldownCounter >= interactCooldown)
        {
            interactCooldownCounter = 0;
              //  Debug.Log("Interacting. Time since last interact: " + interactCooldownCounter);
                if (hit.collider.gameObject.GetComponent<baseInteractable>() != null)
                {
                    hit.collider.gameObject.GetComponent<baseInteractable>().Interact(this);
                }
        }

    }
    private void HighlightUpdate(RaycastHit hit)
    {
            
        if (hit.collider.gameObject.GetComponent<baseInteractable>() != null)
        {
            hit.collider.gameObject.GetComponent<baseInteractable>().Highlight(this);
        }
    }

    //private RaycastHit CheckForward()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, this.transform.forward, out hit, 2f))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //        Debug.Log("HIT");

    //        // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
    //    }
    //    return hit;
    //}
    public void UseActiveTool()
    {
        Debug.Log("UseActiveTool Called");
        activeTool.Use(this);
    }

    public void PickUpTool(BaseTool tool)
    {
        //Type type = typeof(MyObject<>).MakeGenericType(objectType);
        // Type type = tool.GetType();
        Type type = tool.GetType();
        // BaseTool newTool = (BaseTool)Activator.CreateInstance(type);

        BaseTool newTool = gameObject.AddComponent(type) as BaseTool;

        //objToolList.AddComponent<Type>();

        toolList.Add(newTool);
        if (newTool is ActiveTool)
        {
            activeTool = newTool as ActiveTool;
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
    /**
     * Compares the input string to the c# classnames of collected tools
     * */
    public bool HasTool(string toolClassName)
    {

        foreach (var collectedTool in toolList)
        {
            if (collectedTool.GetType().Name == toolClassName)
            {
                return true;
            }
        }
        return false;

    }
    public void Kill()
    {
        isDying = true;
        PlayerMovement.isDying = true;

        state.Loader.ResetLevel(2f);
    }
    /// <summary>
    /// AI-specific move function. Needed for ML-agents
    /// </summary>
    public void MoveRobot(float horizontal, float vertical)
    {

        PlayerMovement.MoveCharacter(horizontal, vertical);
    }
    /// <summary>
    /// Cast a ray forward from this character. Highlight and interact with the first object as needed.
    /// </summary>
    /// <param name="interactAxisInput">Whether or not the interact key was pressed for the current frame. Should be a 0 or a 1 . Should be a boolean</param>
    public void CheckForObject( float interactAxisInput)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.forward, out hit, 2.5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("HIT");
            //  interactAxisInput
            if (interactAxisInput == 1)
            {
                InteractUpdate(hit);
            }
              
            HighlightUpdate(hit);

            // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
        }

        interactCooldownCounter += Time.deltaTime;
       // toolCountdownCounter += Time.deltaTime;
    }

    /// <summary>
    /// Confige this controller to use the correct Unity horizontal, vertical and interact axi's
    /// 
    /// </summary>
    private void SetPlayerControls()
    {
        //if (IsHuman)
        //{
        //    HorizontalAxis = "Horizontal";
        //    VerticalAxis = "Vertical";
        //    Interact = "Interact";
        //}
        //else
        //{
        //    HorizontalAxis = "2-Horizontal";
        //    VerticalAxis = "2-Vertical";
        //    Interact = "2-Interact";
        //}

        if (IsHumanChracter)
        {
            HorizontalAxis = "Horizontal";
            VerticalAxis = "Vertical";
            Interact = "Interact";
            UseTool = "UseTool";
        }
        else //if (state.currentMode == GameState.GameMode.LocalMultiplayer)
        {
            HorizontalAxis = "2-Horizontal";
            VerticalAxis = "2-Vertical";
            Interact = "2-Interact";
            UseTool = "2-UseTool";

        }
    }
}
