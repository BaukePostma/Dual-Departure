using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway :  AbstractActivatable
{
    /// <summary>
    /// A doorway object handles transitions between two rooms
    /// </summary>
    // public baseRoom from;
    // public baseRoom to;
    public GameObject Door;
    public GameObject DoorwayTrigger;

    public string DebugLevelLoadString;
 
   

    private bool humanPlayerIn;
    private bool robotPlayerIn;

    public GameState gameState;

    private void Transition(int index)
    {
        // Transition to new level index
        SceneManager.LoadSceneAsync(index);
    }
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
        // TTemp
     
       // SceneManager.LoadSceneAsync(DebugLevelLoadString);
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
      
        // If one player, send signal
        // If two players, transition
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
        Debug.Log("Doorway Activated");
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
            Debug.Log("Doorway Activated");
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
