using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Input module controlled by the player using unity input system.
public class PlayerInput : ControllerElement, IInput
{
    //interface implementation
    private float _moveInput;
    public float MoveInput
    {
        get => _moveInput;
    }
    private float _rotateInput;
    public float RotateInput
    {
        get => _rotateInput;
    }

    //events sent by unity input system for updating values
    void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }
    void OnRotate(InputValue value)
    {
        _rotateInput = value.Get<float>();
    }

}
