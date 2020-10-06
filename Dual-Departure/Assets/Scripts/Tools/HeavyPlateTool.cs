using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlateTool : PassiveTool
{
    void Start()
    {
        toolName = "Heavy Plate Armour";
        toolDescription = "Protects the wearer from harmfull lasers";
        forHuman = false;
    }
}
