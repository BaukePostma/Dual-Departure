using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlateTool : PassiveTool
{
   
    // Start is called before the first frame update
    void Start()
    {
        toolName = "Heavy Plate Armour";
        toolDescription = "Protects the wearer from harmfull lasers";
       // spritePath = 'no';
        forHuman = false;
    }
}
