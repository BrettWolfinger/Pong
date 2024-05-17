using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//input module for AI control using heuristics
public class AIInput : ControllerElement, IInput
{
    GameObject ball;
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
    
    void Start()
    {
        //need to get reference to ball for movement heuristic
        ball = GameObject.FindGameObjectWithTag("Ball");
        _rotateInput = 0;
    }

    void Update() {
        AIMove();
    }

    private void AIMove()
    {
        //simple AI heuristic, mirroring the y movement of the ball
        //works well enough to return most balls without being unbeatable
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x;
        if(ball.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            _moveInput = -1;
        }
        else
        {
            _moveInput = 1;
        }
    }
    //no current implementation for AI rotate
    void AIRotate(InputValue value)
    {
        _rotateInput = 0;
    }

}
