using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractActivatable : MonoBehaviour
{
    public bool isActive;
    public abstract void Activate();
 
}
