using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    public Doorway target;
    // Start is called before the first frame update
    public bool x = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot") { }
        {
            target.Activate();
        }
    }
}
