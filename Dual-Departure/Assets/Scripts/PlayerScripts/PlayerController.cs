using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class handling player movement, inputs,death and tool usage
/// </summary>
public  class PlayerController : MonoBehaviour
{
    private GameState state;

    // Movement variables
    public Transform groundcheck;
    public LayerMask groundMask;

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
        SetPlayerControls();
        state = GameState.Instance;

        // If this class is used by a robot, dont do updates. Else use unity events to register keypresses
        if (IsControlledByAI)
        {
            // Load brain if this character is controlled by a NN
            PlayerMovement = gameObject.AddComponent<RobotMovement>();
        }
        else
        {
            SetPlayerControls();
            PlayerMovement = gameObject.AddComponent<HumanMovement>();
        }

        PlayerMovement.groundcheck = groundcheck;
        PlayerMovement.groundMask = groundMask;
        PlayerMovement.HorizontalAxis = HorizontalAxis;
        PlayerMovement.VerticalAxis = VerticalAxis;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5)
        {
            Kill();
        }
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
        if (interactCooldownCounter >= interactCooldown)
        {
            interactCooldownCounter = 0;
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

    public void UseActiveTool()
    {
        Debug.Log("UseActiveTool Called");
        activeTool.Use(this);
    }

    public void PickUpTool(BaseTool tool)
    {
        Type type = tool.GetType();
        BaseTool newTool = gameObject.AddComponent(type) as BaseTool;
        toolList.Add(newTool);
        if (newTool is ActiveTool)
        {
            activeTool = newTool as ActiveTool;
            state.UI.SetActiveTool(activeTool);
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

    /// <summary>
    /// Check if the current player has a specific tool
    /// </summary>
    /// <param name="Classname to compare against"></param>
    /// <returns></returns>
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
            if (interactAxisInput == 1)
            {
                InteractUpdate(hit);
            }
            HighlightUpdate(hit);
        }
        interactCooldownCounter += Time.deltaTime;
    }

    /// <summary>
    /// Confige this controller to use the correct Unity horizontal, vertical and interact axi's
    /// 
    /// </summary>
    private void SetPlayerControls()
    {
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
