using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup-object that gives a tool to the player when they touch it
/// </summary>
public class ToolPickupObject : MonoBehaviour
{
    public BaseTool tool;
    public Material mat;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Human" && tool.forHuman == true || collision.gameObject.tag == "Robot" && tool.forHuman == false)
        {
            collision.gameObject.GetComponent<PlayerController>().PickUpTool(this.tool);
            Destroy(this.gameObject);

            //debug
            mat.color = Color.blue;
        }
    }
}
