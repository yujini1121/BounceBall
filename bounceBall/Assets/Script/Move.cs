using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 12.0f;
    private Rigidbody2D moveRigidbody;
    private Vector2 newVelocity;
    private bool goLeft;
    private bool goRight;

    void Start()
    {
        moveRigidbody = GetComponent<Rigidbody2D>();
        moveRigidbody.gravityScale = 0f;
        goLeft = false;
        goRight = true;
    }

    void Update()
    {
        if (goRight && !goLeft)
        {
            newVelocity = new Vector2(moveSpeed, moveRigidbody.velocity.y);
            moveRigidbody.velocity = newVelocity;
        }
        else if(!goRight && goLeft)
        {
            newVelocity = new Vector2(-moveSpeed, moveRigidbody.velocity.y);
            moveRigidbody.velocity = newVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Station")
        {
            if (goRight)
            {
                goLeft = true;
                goRight = false;
            }
            else if (goLeft)
            {
                goLeft = false;
                goRight = true;
            }
        }
    }
}