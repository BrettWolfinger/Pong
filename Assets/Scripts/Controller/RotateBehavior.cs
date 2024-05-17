using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateBehavior : ControllerElement
{
    [SerializeField] GameObject leftThrust;
    [SerializeField] GameObject rightThrust;
    public void Rotate(float input)
    {
        controller.rb.MoveRotation(controller.rb.rotation+input*controller.rotateSpeed*Time.fixedDeltaTime);
        
        //Apply appropriate thrust graphics
        if(input < 0)
        {
            leftThrust.SetActive(true);
        }
        else if(input > 0)
        {
            rightThrust.SetActive(true);
        }
        else
        {
            leftThrust.SetActive(false);
            rightThrust.SetActive(false);
        }
    }
}
