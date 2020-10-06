using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spin the object this class is attached to.
/// </summary>
public class ToolSpin : MonoBehaviour
{
    public float spinspeed = 5;

    void Update()
    {
        transform.Rotate(0, spinspeed * Time.deltaTime, 0);
    }
}
