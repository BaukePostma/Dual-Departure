using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasValve : baseInteractable
{
    public AbstractActivatable[] leaks;
    public Animator anim;

    public override void Interact(PlayerController player)
    {
        anim.SetTrigger("Spin");
        foreach (var leak in leaks)
        {
            leak.Activate();
        }
    }

}
