using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for passive and active player abilities
/// </summary>
public abstract class BaseTool : MonoBehaviour
{
    protected string toolName = "Default Name";
    protected string toolDescription = "Default Description";
    public string spritePath;
    public bool forHuman;

    public string getName()
    {
        return toolName;
    }
    public string getDescription()
    {
        return toolDescription;
    }
}

