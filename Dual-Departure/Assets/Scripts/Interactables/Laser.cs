using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    bool isActive = true;
    public LineRenderer line;
    public ParticleSystem impactSparks;

    // Start is called before the first frame update
    void Start()
    {
       // line = GetComponent<LineRenderer>();
        line.SetPosition(0, this.transform.position);
            impactSparks.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, this.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.DrawLine(this.transform.position, hit.point);
                Debug.Log(hit.point);
                line.SetPosition(1, hit.point);
                impactSparks.transform.position = hit.point;
             
                if (hit.collider.tag == "Human" || hit.collider.tag == "Robot")
                {
                    var player = hit.collider.GetComponent<PlayerController>();
                    if (player.HasTool("HeavyPlateTool"))
                    {
                        Debug.Log("Target has HeavyPlateTool");
                    }
                    else
                    {
                        Debug.Log("Target does not have HeavyPlateTool");
                        hit.collider.GetComponent<PlayerController>().Kill();

                    }
                }
                // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
            }
            Debug.Log("No Hit");
        }
       
    }

    void Toggle()
    {

    }
}
