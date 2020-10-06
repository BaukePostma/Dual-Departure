using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

/// <summary>
/// Class used to train and control the NN agent. Not being used in this verison of the game
/// </summary>
public class Partner : Agent
{
    Camera cam;
    PlayerController controller;

    public Doorway levelEnd;
    public PushableBoulder boulder;
    public PressurePlateDetector plate;

    public RayPerceptionSensor raySensor;
    public TextMesh scoreText;

    Vector3 origpos;
    void Start()
    {
        origpos = transform.position;
        controller = GetComponent<PlayerController>();
        cam = Camera.main;

    }
    public override void OnEpisodeBegin()
    {
        transform.position = origpos;


        resetLevel();
        if (this.transform.localPosition.y < 0)
        {
            // If the Agent fell, zero its momentum

            //    this.robotChar.angularVelocity = Vector3.zero;
            //    this.robotChar.velocity = Vector3.zero;
            //    this.transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        // Move the target to a new spot
        //Target.localPosition = new Vector3(Random.value * 8 - 4,
        //                                   0.5f,
        //                                   Random.value * 8 - 4);
    }
 

    public override void CollectObservations(VectorSensor sensor)
    {
        // What information about the enviroment does this agent need to complete the task?
        // Target and Agent positions

        //sensor.AddObservation(Target.localPosition);
        //sensor.AddObservation(this.transform.localPosition);

        //// Agent velocity
        //sensor.AddObservation(robotChar.velocity.x);
        //sensor.AddObservation(robotChar.velocity.z);

       // RenderTexture camshot = cam.targetTexture;
       
        //if (camshot != null)
        //{
        //   // sensor.AddObservation(camshot);
        //}
        //else
        //{
        //    Debug.Log("Camshot not defined");
        //}

      

        sensor.AddObservation(levelEnd.isActive);
        sensor.AddObservation(levelEnd.transform.position.x);
        sensor.AddObservation(levelEnd.transform.position.z);

        //sensor.AddObservation(plate.transform.position.x);
        //sensor.AddObservation(plate.transform.position.z);
        //sensor.AddObservation(boulder.transform.position.x);
        //sensor.AddObservation(boulder.transform.position.z);
        sensor.AddObservation(Vector3.Distance(this.transform.localPosition, levelEnd.transform.localPosition));
        sensor.AddObservation(Vector3.Distance(plate.transform.position, boulder.transform.position));
       // sensor.AddObservation(transform.position);

       // Debug.Log(boulder.transform.position.x);
        //Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), camshot);
    }
    public float speed = 10;

    public override void OnActionReceived(float[] vectorAction)
    {
      
        //Debug.Log(vectorAction[0].ToString());
        //Debug.Log(vectorAction[1].ToString());
        //Debug.Log(vectorAction[2].ToString());

        // Receives signals and assigns rewards

        // Actions, size = 2
        //Vector3 controlSignal = Vector3.zero;
        //controlSignal.x = vectorAction[0];
        //controlSignal.z = vectorAction[1];
        // robotChar.AddForce(controlSignal * speed);

        // No idea if this works
        controller.MoveRobot(vectorAction[0], vectorAction[1]);

        if (vectorAction[2] >= 0.5f)
        {
            controller.CheckForObject(1);
            //controller.Interac
        }
        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, levelEnd.transform.localPosition);
        Debug.Log(distanceToTarget);
        // Reached target
        if (distanceToTarget < 2.5f && levelEnd.isActive)
        {
            resetLevel();
            SetReward(1.0f);
            EndEpisode();
            Debug.Log("Got reward");

        }

        float distancetoBoulder = Vector3.Distance(this.transform.localPosition, boulder.transform.position);
        if (distancetoBoulder < 1.5f)
        {
           // scoreText.text += 0.002f;
            Debug.Log("Close to boulder");
            SetReward(0.002f);
        }
        float distancetopressure = Vector3.Distance(plate.transform.position, boulder.transform.position);
        if (distancetopressure < 0.5f)
        {
            SetReward(0.2f);
            // SetReward(5 - distancetopressure);
        }
        //else
        //{
        //    Debug.Log("Participation prize: " + (0.1f - (distancetoBoulder / 100)));
        //    SetReward(0.1f  - (distancetoBoulder / 100));
        //}


        // Fell off platform
        if (this.transform.localPosition.y < 0)
        {
            Debug.Log("Got reset");

            EndEpisode();
        }
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("2-Horizontal");
        actionsOut[1] = Input.GetAxis("2-Vertical");
        actionsOut[2] = Input.GetAxis("2-Interact");
    }
    
    public void resetLevel()
    {
        boulder.transform.position = new Vector3(Random.value * 8 - 4,
                                           0.5f,
                                           Random.value * 8 - 4);
      //  scoreText.text = 0;
       // boulder.transform.position = boulder.origpos;
        levelEnd.isActive = false;
    }
}
