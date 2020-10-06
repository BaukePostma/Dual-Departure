using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The end of the level. 
/// </summary>
public class Doorway : AbstractActivatable
{
    // public baseRoom from;
    // public baseRoom to;

    public GameState gameState;

    public GameObject Door;
    public GameObject DoorwayTrigger;
    public string DebugLevelLoadString;

    //Check if both players are inside the Doorway trigger
    private bool humanPlayerIn;
    private bool robotPlayerIn;

    //private void Transition(int index)
    //{
    //    SceneManager.LoadSceneAsync(index);
    //}
    void Start()
    {
        gameState = GameState.Instance;

        if (isActive)
        {
            DoorwayTrigger.SetActive(true);
        }
        else
        {
            DoorwayTrigger.SetActive(false);
        }
    }

    private void Transition()
    {
        if (!string.IsNullOrWhiteSpace(DebugLevelLoadString))
        {
            gameState.Loader.LoadLevel(DebugLevelLoadString);
        }
        else
        {
            gameState.Loader.LoadNextLevel();
        }
    }
    public void TriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.gameObject.tag == "Human")
            {
                humanPlayerIn = true;
            }
            else if (other.gameObject.tag == "Robot")
            {
                robotPlayerIn = true;
            }

            if (humanPlayerIn && robotPlayerIn)
            {
                Transition();
            }
        }
    }

    public void TriggerLeave(Collider other)
    {
        if (other.gameObject.tag == "Human")
        {
            humanPlayerIn = false;
        }
        else if (other.gameObject.tag == "Robot")
        {
            robotPlayerIn = false;
        }
    }

    public override void Activate()
    {
        this.isActive = true;
        OpenDoor();
    }
    public void Toggle()
    {
        if (isActive)
        {
            isActive = false;
            CloseDoor();
        }
        else
        {
            isActive = true;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        //this.Door.transform.position += new Vector3(0, 1, 0);
        this.DoorwayTrigger.SetActive(true);
    }
    private void CloseDoor()
    {
        //this.Door.transform.position += new Vector3(0, 1, 0);
        this.DoorwayTrigger.SetActive(false);
    }
}
