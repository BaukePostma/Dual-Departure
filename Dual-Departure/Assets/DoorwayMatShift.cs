using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayMatShift : MonoBehaviour
{
    Material mat;
    Color newcolor;
    
    float alphaCounter;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        newcolor = new Color();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void changeColor()
    {
        alphaCounter += 1 * Time.deltaTime;
        newcolor = mat.color;

        // newcolor.a = Mathf.Clamp(alphaCounter,50,150);
        newcolor.a = Mathf.Sin(10) * alphaCounter;

        mat.color = newcolor;
    }
}
