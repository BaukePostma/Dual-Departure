using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
// Ugly code for the NN. Makes it so that the human player gets inputs via keyboard events, but an AI gets it from the ML-agents brain
public class HumanMovement : baseMovement
{
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw(this.HorizontalAxis);
        float moveVertical = Input.GetAxisRaw(this.VerticalAxis);
        this.MoveCharacter(moveHorizontal, moveVertical);
    }
}
