using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : baseInteractable
{
    public GasLeak[] leaks;
    public Animator anim;

    public override void Interact(PlayerController player)
    {
        anim.SetTrigger("Spin");
        Debug.Log("Interact called");
        foreach (var leak in leaks)
        {
            leak.Toggle();
        }
    }

}
