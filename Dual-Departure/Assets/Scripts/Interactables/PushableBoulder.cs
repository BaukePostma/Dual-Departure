using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushableBoulder : baseInteractable
{
    public float interactForce = 2000;
    public Vector3 origpos;
    
    public override void Interact(PlayerController player)
    {
        // Apply foce from the direction of the player
        Debug.Log("Interacted");
        this.GetComponent<Rigidbody>().AddForce(player.transform.forward.normalized * interactForce);
    }

    public void ApplyForce(Vector3 direction)
    {
        // Apply forrce from the direction of the player
        this.GetComponent<Rigidbody>().AddForce(direction.normalized * (interactForce/4));
    }

    void Start()
    {
        origpos = transform.position;
    }

    public  void Update()
    {
        // Reset the ball
        if (transform.position.y < -5f)
        {
            transform.position = origpos;
        }
    }
   
}
