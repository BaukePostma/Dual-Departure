using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasLeak : MonoBehaviour
{
    public bool isActive;
    private ParticleSystem gas;
    // Start is called before the first frame update
    void Start()
    {
        gas = GetComponent<ParticleSystem>();
        // By default the gas is on.
        if (!isActive)
        {
            gas.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    // Update is called once per frame
    void Update()
    {
 
      
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
        if (isActive == true && other.gameObject.tag == "Human")
        {
            Debug.Log(isActive);
            Debug.Log("Oh Noes Human hit by gas. Respawn?");
            other.GetComponent<PlayerController>().Kill();
            //Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
