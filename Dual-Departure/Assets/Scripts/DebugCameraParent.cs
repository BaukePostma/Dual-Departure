using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraParent : MonoBehaviour
{
    public Camera cam;
    public GameObject target;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = target.transform.position + new Vector3(0,10,0);
    }
}
