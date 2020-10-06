using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A tool that can be used by pressing the 'use' button
/// </summary>
public abstract class ActiveTool : BaseTool
{

    public virtual void Use(PlayerController player)
    {
        Debug.Log("Using" + this.toolName);
        Debug.Log("Used by " + player.tag);
    }
}
