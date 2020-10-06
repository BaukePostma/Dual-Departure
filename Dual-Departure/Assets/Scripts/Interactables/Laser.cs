using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : AbstractActivatable
{
    public LineRenderer line;
    public ParticleSystem impactSparks;

    void Start()
    {
        line.SetPosition(0, this.transform.position);
        impactSparks.Play();
    }

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
                    }
                }
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
