using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasLeak : AbstractActivatable
{
    private ParticleSystem gas;
    private GameState gameState;

    void Start()
    {
        gameState = GameState.Instance;
        gas = GetComponent<ParticleSystem>();
        // By default the gas is on.
        if (!isActive)
        {
            gas.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }
    public void Toggle()
    {
        Debug.Log("Toggle called");
        if (isActive)
        {
            isActive = false;
            gas.Stop(false,ParticleSystemStopBehavior.StopEmitting);
        }
        else
        {
            isActive = true;
            gas.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        TouchGas(other);
    }
    private void OnTriggerStay(Collider other)
    {
        TouchGas(other);
    }

    private void TouchGas(Collider other)
    {
        if (isActive == true && other.gameObject.tag == "Human")
        {
            other.GetComponent<PlayerController>().Kill();
        }else if  (other.gameObject.GetComponent<PushableBoulder>() && isActive == true )
        {
            other.gameObject.GetComponent<PushableBoulder>().ApplyForce(this.transform.forward);
        }else if(other.gameObject.GetComponent<MagneticBoulder>() && isActive == true)
        {
            other.gameObject.GetComponent<MagneticBoulder>().ApplyForce(this.transform.forward);
        }
    }

    public override void Activate()
    {
        Toggle();
    }
}
