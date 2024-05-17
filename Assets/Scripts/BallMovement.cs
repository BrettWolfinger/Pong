using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour, IResetable
{
    [SerializeField] float moveSpeed = 3f;

    Rigidbody2D rb;
    Vector2 velocity;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    //Change movement of ball after colliding with something
    private void OnCollisionEnter2D(Collision2D other) {
        audioSource.Play();
        velocity = Vector2.Reflect(velocity, other.contacts[0].normal);
        rb.velocity = velocity;
        if(other.gameObject.tag == "SuperBounce")
        {
            rb.velocity *= 3;
        }
    }

    //Resets ball back to the middle of the field after scoring a goal
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Reset();
    }

    //Chooses a starting velocity for the ball out of 4 options
    private Vector2 GenerateStartingVelocity()
    {
        int x  = Random.Range(0,2) < 1 ? -1 : 1;
        int y = Random.Range(0,2) < 1 ? -1 : 1;
        return new Vector2 (x*moveSpeed, y*moveSpeed);
    }

    public void Reset() 
    {
        transform.position = new Vector2(0,0);
        velocity = GenerateStartingVelocity();
        rb.velocity = velocity;
    }
}
