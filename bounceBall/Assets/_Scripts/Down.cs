using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    public Down down;
    private Rigidbody2D downRigid;
    private bool touchingWithPlayer;
    private bool bottomTouchingWithPlayer;
    private bool touchingWithGround;
    

    //test var
    [SerializeField] float gravity = 0.98f;

    void Start() 
    {
        downRigid = GetComponent<Rigidbody2D>();
        touchingWithPlayer = false;
        bottomTouchingWithPlayer = false;
        touchingWithGround = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touchingWithPlayer = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            touchingWithGround = true;
        }
    }

    // 경우의 수
    // 1. 윗면과 플레이어가 닿았는가
    // 2. 아랫면과 플레이어가 닿았는가
    // 3. 평지와 닿았는가
    // 주석처리된 코드는 body type을 변경하여 구현한 경우
    void Update() 
    {
        if (touchingWithGround) {
            transform.position = new Vector2(transform.position.x, 18);
            return;
        }

        if (touchingWithPlayer && !bottomTouchingWithPlayer && !touchingWithGround)
        {
            Debug.Log("낙하!");
            transform.position = new Vector2(transform.position.x,
                                            transform.position.y - ((1 - gravity) * Time.deltaTime * 30f));
            gravity *= 0.98f;
            //downRigid.isKinematic = false;
            //downRigid.gravityScale = 9.8f;
        }

        else
        {
            Debug.Log("제자리!");
            //downRigid.isKinematic = true;
            //downRigid.gravityScale = 0f;
        }
    }
}