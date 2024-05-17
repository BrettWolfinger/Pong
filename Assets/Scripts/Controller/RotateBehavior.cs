using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateBehavior : ControllerElement
{
    public void Rotate(float input)
    {
        controller.rb.MoveRotation(controller.rb.rotation+input*controller.rotateSpeed*Time.fixedDeltaTime);
    }
}
