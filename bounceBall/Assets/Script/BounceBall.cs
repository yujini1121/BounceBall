using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    public BounceBall bounceBall;
    public float speed;
    public float jumpBoost;
    public float shooterSpeed;
    public bool touchingWithR_Shooter;
    public bool touchingWithL_Shooter;
    private Rigidbody2D ballRigidbody;
    private Vector2 newVelocity;
    private float orig_y = 32f;   // 공 기본 y(점프)값
    private bool hit;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        touchingWithR_Shooter = false;
        touchingWithL_Shooter = false;
        hit = false;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;
        newVelocity = new Vector2(xSpeed, ballRigidbody.velocity.y);
        ballRigidbody.velocity = newVelocity;

        //L_Shooter
        if (touchingWithL_Shooter && xInput == 0) 
        {
            ballRigidbody.gravityScale = 0f;
            transform.position -= transform.right * shooterSpeed;
            newVelocity = new Vector2(ballRigidbody.velocity.x, 0f);
            ballRigidbody.velocity = newVelocity;
        }
        else if (xInput != 0)
        {
            touchingWithL_Shooter = false;
            ballRigidbody.gravityScale = 9.8f;
        }

        //R_Shooter
        if (touchingWithR_Shooter && xInput == 0) 
        {
            ballRigidbody.gravityScale = 0f;
            transform.position += transform.right * shooterSpeed;
            newVelocity = new Vector2(ballRigidbody.velocity.x, 0f);
            ballRigidbody.velocity = newVelocity;
        }
        else if (xInput != 0)
        {
            touchingWithR_Shooter = false;
            ballRigidbody.gravityScale = 9.8f;
        }

        //L_Shooter, R_Shooter 공통
        if (touchingWithL_Shooter || touchingWithR_Shooter)
            if (hit)
                {
                    touchingWithL_Shooter = false;
                    touchingWithR_Shooter = false;
                    ballRigidbody.gravityScale = 9.8f;
                }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 newVelocity = new Vector2(ballRigidbody.velocity.x, orig_y);
        ballRigidbody.velocity = newVelocity;

        switch(other.gameObject.tag)
        {
            case "Ground":
                ballRigidbody.velocity = newVelocity;
                hit = true;
                break;

            case "JumpBlock":
                newVelocity = new Vector2(ballRigidbody.velocity.x, orig_y * jumpBoost);
                ballRigidbody.velocity = newVelocity;
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