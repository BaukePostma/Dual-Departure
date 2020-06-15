using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDetector : MonoBehaviour
{
    //  public Collider trigger;
    private Collider trigger;
    public GameObject TargetToDetect;
    public Doorway PlatePressedTarget;
    // Start is called before the first frame update
    void Start()
    {
        trigger = this.GetComponent<Collider>();
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
        if (GameObject.ReferenceEquals(other.gameObject, TargetToDetect))
        {
            Debug.Log("Target detected");
            PlatePressedTarget.Activate();
        }

        if(other.tag == "Boulder")
        {
            Debug.Log("Hit a boulder");
            //other.GetComponent<render>
        }
     
    }
}
