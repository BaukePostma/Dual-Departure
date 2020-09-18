using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTool : ActiveTool
{
    
  private void Start()
    {
        this.toolName = "MagnetTool";
        this.toolDescription = "Pull magnetic objects towards you";
        this.spritePath = "Magnet";
    }
    public override void Use(PlayerController player)
    {
        base.Use(player);

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 60f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.gameObject.GetComponent<IIsMagnetic>() != null)
            {
                hit.collider.gameObject.GetComponent<IIsMagnetic>().ApplyMagneticForce(player.transform.forward, hit.distance);
                Debug.Log("Magnetic target hit with the raycast");
            }
        }
    }
}
