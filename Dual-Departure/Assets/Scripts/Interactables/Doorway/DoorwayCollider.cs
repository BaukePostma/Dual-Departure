using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<Doorway>().TriggerEnter(c);
    }
    void OnTriggerExit(Collider c)
    {
        gameObject.GetComponentInParent<Doorway>().TriggerLeave(c);
    }
}
