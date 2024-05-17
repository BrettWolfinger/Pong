using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : ControllerElement
{
    public void Move(float input)
    {
        controller.rb.MovePosition(controller.rb.position + new Vector2(0,input*controller.moveSpeed*Time.fixedDeltaTime));
    }
}
