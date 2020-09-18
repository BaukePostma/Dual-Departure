using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBoulder : MonoBehaviour, IIsMagnetic
{
    public float magneticForce = 200f;

    private Rigidbody rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    public void ApplyForce(Vector3 direction)
    {

        rBody.AddForce(direction.normalized * (magneticForce));
    }

    public void ApplyMagneticForce(Vector3 magPosition, float distance)
    {
        rBody.AddForce(-magPosition.normalized / distance * magneticForce );
       
    }

}
