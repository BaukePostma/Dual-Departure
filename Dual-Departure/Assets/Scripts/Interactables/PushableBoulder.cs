using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Boulder that can be ushed around by interacting with it
/// </summary>
public class PushableBoulder : baseInteractable
{
    public float interactForce = 2000;
    public Vector3 origpos;
    
    public override void Interact(PlayerController player)
    {
        // Apply foce from the direction of the player
        this.GetComponent<Rigidbody>().AddForce(player.transform.forward.normalized * interactForce);
    }

    // Seperate function for the gasleaks to call. 
    // TODO: Have Interact call this method 
    public void ApplyForce(Vector3 direction)
    {
        this.GetComponent<Rigidbody>().AddForce(direction.normalized * (interactForce/4));
    }

    void Start()
    {
        origpos = transform.position;
    }

    public void Update()
    {
        // Reset the ball for NN training 
        if (transform.position.y < -5f)
        {
            transform.position = origpos;
        }
    }
   
}
