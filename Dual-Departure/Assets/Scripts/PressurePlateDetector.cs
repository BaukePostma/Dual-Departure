using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDetector : MonoBehaviour
{
    public Collider trigger;
    // Start is called before the first frame update
    void Start()
    {
        //trigger = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //trigger.Ont
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if other === CustomCollider
        // If true, call Trigger()
        if(other.tag == "Boulder")
        {
            Debug.Log("Hit a boulder");
            //other.GetComponent<render>
        }
     
    }
}
