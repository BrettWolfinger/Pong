using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerElement : MonoBehaviour
{
    public Controller controller { get { return GetComponent<Controller>(); }}
}
public class Controller : MonoBehaviour
{
    public IInput input;
    public MoveBehavior move;
    public RotateBehavior rotate;
    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        move.Move(input.MoveInput);
        rotate.Rotate(input.RotateInput);
    }
}