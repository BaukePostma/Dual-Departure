using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDetector : MonoBehaviour
{
    //  public Collider trigger;
    private Collider trigger;
    public GameObject TargetToDetect;
    public Doorway PlatePressedTarget;

    private bool isSinking;
    private Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        trigger = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            //Slowly move the pressure plate down
            transform.position -= new Vector3(0, 0.15f, 0) * Time.deltaTime;
            float heightDifference = origPos.y - transform.position.y;
            if (heightDifference > origPos.y)
            {
                isSinking = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if other === CustomCollider
        // If true, call Trigger()
        if (GameObject.ReferenceEquals(other.gameObject, TargetToDetect))
        {
            Debug.Log("Target detected");
            PlatePressedTarget.Activate();
            Sink();
        }
    }
    private void Sink()
    {
        isSinking = true;
    }
    public void ResetPlate()
    {
        
    }
}
