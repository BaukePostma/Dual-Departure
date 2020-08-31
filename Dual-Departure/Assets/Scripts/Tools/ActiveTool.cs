using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : BaseTool
{

    public virtual void Use(PlayerController player)
    {
        Debug.Log("Using" + this.toolName);
        Debug.Log("Used by " + player.tag);
    }
}
