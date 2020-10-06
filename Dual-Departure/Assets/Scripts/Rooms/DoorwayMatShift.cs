using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayMatShift : MonoBehaviour
{
    Material mat;
    Color newcolor;
    float alphaCounter;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        newcolor = new Color();
    }
    void changeColor()
    {
        alphaCounter += 1 * Time.deltaTime;
        newcolor = mat.color;
        newcolor.a = Mathf.Sin(10) * alphaCounter;
        mat.color = newcolor;
    }
}
