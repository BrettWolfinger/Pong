using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : ControllerElement, IInput
{
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
    void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }
    void OnRotate(InputValue value)
    {
        _rotateInput = value.Get<float>();
    }

}
