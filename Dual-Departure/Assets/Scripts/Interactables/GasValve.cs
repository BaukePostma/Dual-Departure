using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : MonoBehaviour, IInteractable
{
    public GasLeak[] leaks;
    public void Highlight(GameObject player)
    {
        
    }

    public void Interact(GameObject player)
    {
        Debug.Log("Interact called");
        foreach (var leak in leaks)
        {
            leak.Toggle();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
