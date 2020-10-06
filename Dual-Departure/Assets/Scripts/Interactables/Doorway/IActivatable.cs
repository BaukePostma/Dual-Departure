using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any object that needs to be turned on or off, like doorways and gasleaks
/// </summary>
public abstract class AbstractActivatable : MonoBehaviour
{
    public bool isActive;
    public abstract void Activate();
}
