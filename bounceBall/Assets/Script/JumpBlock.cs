using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         //BounceBall script에 선언된 변수 가져오기
    //         GameObject temp = GameObject.Find("BounceBall");
    //         Rigidbody2D ballRigidbody = temp.GetComponent<BounceBall>().ballRigidbody;
    //         Vector2 newVelocity = temp.GetComponent<BounceBall>().newVelocity;
    //         float orig_y = temp.GetComponent<BounceBall>().orig_y;
    //         float jumpBoost = temp.GetComponent<BounceBall>().jumpBoost;
    //         bool hit = temp.GetComponent<BounceBall>().hit;

    //         //JumpBlock
    //         newVelocity = new Vector2(ballRigidbody.velocity.x, orig_y * jumpBoost);
    //         ballRigidbody.velocity = newVelocity;
    //         hit = true;
    //     }
    // }
}
