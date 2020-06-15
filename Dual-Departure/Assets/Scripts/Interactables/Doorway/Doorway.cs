using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    /// <summary>
    /// A doorway object handles transitions between two rooms
    /// </summary>
    // public baseRoom from;
    // public baseRoom to;
    public GameObject Door;
    public GameObject DoorwayTrigger;

    public string DebugLevelLoadString;
    public bool isActive;
   

    private bool humanPlayerIn;
    private bool robotPlayerIn;

    private void Transition(int index)
    {
        // Transition to new level index
        SceneManager.LoadSceneAsync(index);
    }

    private void Transition()
    {
        // TTemp
        SceneManager.LoadSceneAsync(DebugLevelLoadString);
    }
    public void TriggerEnter(Collider other)
    {
   
        if (isActive)
        {
            if (other.gameObject.tag == "Human")
            {
                Debug.Log("Human is IN");
                humanPlayerIn = true;
            }
            else if (other.gameObject.tag == "Robot")
            {
                Debug.Log("Robot is IN");

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
        Debug.Log("OnTriggerLEave");
        if (other.gameObject.tag == "Human")
        {
            Debug.Log("Human is OUT");

            humanPlayerIn = false;
        }
        else if (other.gameObject.tag == "Robot")
        {
            Debug.Log("Robot is OUT");

            robotPlayerIn = false;
        }
    }

    public void Activate()
    {
        Debug.Log("Doorway Activated");
        this.isActive = true;
        OpenDoor();
    }
    private void OpenDoor()
    {
        this.Door.transform.position += new Vector3(0, 1, 0);
        this.DoorwayTrigger.SetActive(true);
    }

}
