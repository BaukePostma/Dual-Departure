using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveTool : BaseTool
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Use()
    {
        Debug.Log("Using" + this.ToolName);
    }
}
