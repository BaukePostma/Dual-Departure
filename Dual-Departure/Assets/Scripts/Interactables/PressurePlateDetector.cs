using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDetector : MonoBehaviour
{
    //  public Collider trigger;
    private Collider trigger;
    public GameObject TargetToDetect;
    public bool OnlyActivateOnce = true;
    private bool alreadyTriggerd = false;
    public AbstractActivatable PlatePressedTarget;

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

    private  void OnTriggerEnter(Collider other)
    {
        if (OnlyActivateOnce && !alreadyTriggerd || !OnlyActivateOnce)
        {
            // Check if other === TargetToDetect.  If true, call Activate() on other.
            if (GameObject.ReferenceEquals(other.gameObject, TargetToDetect))
            {
                alreadyTriggerd = true;
                Debug.Log("Target detected");
                PlatePressedTarget.Activate();
                Sink();
            }
        }
       
    }

    private void Sink()
    {
        isSinking = true;
    }

}
