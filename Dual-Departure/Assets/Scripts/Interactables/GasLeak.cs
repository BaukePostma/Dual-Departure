using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasLeak : MonoBehaviour
{
    public bool isActive;
    private ParticleSystem gas;
    private GameState gameState;

    private Coroutine resetLevel;
    // Start is called before the first frame update
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
            Debug.Log(isActive);
            Debug.Log("Oh Noes Human hit by gas. Respawn?");
            other.GetComponent<PlayerController>().Kill();

            gameState.Loader.ResetLevel(2);
            //Scene scene = SceneManager.GetActiveScene();
            //StartCoroutine(ResetLevel());

        }else if (isActive == true && other.gameObject.GetComponent<PushableBoulder>())
        {
            other.gameObject.GetComponent<PushableBoulder>().ApplyForce(this.transform.forward);
        }
    }
    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
