using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickupObject : MonoBehaviour
{
    //public GameObject Model;
    public BaseTool tool;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        //mat = this.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
