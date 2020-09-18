using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : AbstractActivatable
{
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

                line.SetPosition(1, hit.point);
                impactSparks.transform.position = hit.point;
             
                if (hit.collider.tag == "Human" || hit.collider.tag == "Robot")
                {
                    var player = hit.collider.GetComponent<PlayerController>();
                    if (!player.HasTool("HeavyPlateTool"))
                    {
                        hit.collider.GetComponent<PlayerController>().Kill();
                        Debug.Log("Target has HeavyPlateTool");
                    }
                }
                // hit.collider.gameObject.transform.position += new Vector3(0,50,0);
            }
        
        }
       
    }

    public void Toggle()
    {
        Debug.Log("Toggle called");
        if (isActive)
        {
            isActive = false;
            line.enabled = false;
            impactSparks.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
        else
        {
            isActive = true;
            line.enabled = true;
            impactSparks.Play();
        }
    }

    public override void Activate()
    {
        Toggle();
    }
}
