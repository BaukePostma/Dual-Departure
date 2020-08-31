using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpin : MonoBehaviour
{
    public float spinspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // float spinspeed = 5 * Time.deltaTime;
        // transform.Rotate(0, spinspeed*20, spinspeed*5);
        transform.Rotate(0, spinspeed * Time.deltaTime, 0);

    }
}
