using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    public BounceBall bounceBall;
    public float speed;
    public float jumpBoost;
    public float shooterSpeed;
    public bool touchedR;
    public bool touchedL;
    private Rigidbody2D ballRb;
    private Vector2 newVelocity;
    private float originY = 32f;   // 공 기본 y(점프)값
    private bool hit;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        touchedR = false;
        touchedL = false;
        hit = false;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;
        newVelocity = new Vector2(xSpeed, ballRb.velocity.y);
        ballRb.velocity = newVelocity;

        //L_Shooter
        if (touchedL && xInput == 0) 
        {
            ballRb.gravityScale = 0f;
            transform.position -= transform.right * shooterSpeed;
            newVelocity = new Vector2(ballRb.velocity.x, 0f);
            ballRb.velocity = newVelocity;
        }
        else if (xInput != 0)
        {
            touchedL = false;
            ballRb.gravityScale = 9.8f;
        }

        //R_Shooter
        if (touchedR && xInput == 0) 
        {
            ballRb.gravityScale = 0f;
            transform.position += transform.right * shooterSpeed;
            newVelocity = new Vector2(ballRb.velocity.x, 0f);
            ballRb.velocity = newVelocity;
        }
        else if (xInput != 0)
        {
            touchedR = false;
            ballRb.gravityScale = 9.8f;
        }

        //L_Shooter, R_Shooter 공통
        if (touchedL || touchedR)
            if (hit)
                {
                    touchedL = false;
                    touchedR = false;
                    ballRb.gravityScale = 9.8f;
                }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 newVelocity = new Vector2(ballRb.velocity.x, originY);
        ballRb.velocity = newVelocity;

        switch(other.gameObject.tag)
        {
            case "Ground":
                ballRb.velocity = newVelocity;
                hit = true;
                break;

            case "JumpBlock":
                newVelocity = new Vector2(ballRb.velocity.x, originY * jumpBoost);
                ballRb.velocity = newVelocity;
                hit = true;
                break;

            case "L_Shooter":
                hit = false;
                break;

            case "R_Shooter":
                hit = false;
                break;

            case "Fall":
                bounceBall.Die();
                break;

            case "Spike":
                bounceBall.Die();
                hit = true;
                break;

            case "Thunder":
                bounceBall.Die();
                break;

            /*case "R_Shooter":
                //1. R_Shooter의 오른쪽으로 순간 이동 (Find를 최소한 적게 쓰는 방법)
                //transform.position = new Vector2(GameObject.Find("R_Shooter").transform.position.x + 1.5f, GameObject.Find("R_Shooter").transform.position.y);
                GameObject temp = GameObject.Find("R_Shooter");
                transform.position = new Vector2(temp.transform.position.x + 1.5f, temp.transform.position.y);

                //2. 오른쪽으로 이동
                touchingWithR_Shooter = true;
                break;*/
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameOver();
    }
}