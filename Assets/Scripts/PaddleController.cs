using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour, IResetable
{

    float rawInput;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float AIMoveSpeed = 8f;
    bool isAI = false;
    Vector3 originalPosition;

    GameObject ball;

    // initialize components and store original position for resets
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        originalPosition = this.transform.position;
    }

    //Decide which control scheme to use
    void Update()
    {
        if(!isAI)
        {
            PlayerMove();
        }
        else
        {
            AIMove();
        }
    }

    void PlayerMove()
    {
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x;
        newPos.y = transform.position.y + rawInput*moveSpeed*Time.deltaTime;
        rb.MovePosition(newPos);
    }

    private void AIMove()
    {
        //simple AI heuristic, mirroring the y movement of the ball
        //works well enough to return most balls without being unbeatable
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x;
        if(ball.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            newPos.y = transform.position.y - AIMoveSpeed*Time.deltaTime;
        }
        else
        {
            newPos.y = transform.position.y + AIMoveSpeed*Time.deltaTime;
        }

        rb.MovePosition(newPos);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<float>();
    }

    public void SetAI(bool useAI)
    {
        isAI = useAI;
    }

    public void Reset()
    {
        this.transform.position = originalPosition;
    }
}
