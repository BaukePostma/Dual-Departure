using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : baseMovement
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw(this.HorizontalAxis);
        float moveVertical = Input.GetAxisRaw(this.VerticalAxis);

        this.MoveCharacter(moveHorizontal, moveVertical);
    }
}
