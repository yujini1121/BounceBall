using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Shooter : MonoBehaviour
{
    private bool bounceBall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("R_Shooter");
            //1. R_Shooter의 오른쪽으로 순간 이동 (Find를 최소한 적게 쓰는 방법)
            //GameObject temp = GameObject.Find("BounceBall");
            GameObject temp = other.gameObject;
            temp.transform.position = new Vector2(transform.position.x + 1.5f, transform.position.y);

            //2. 오른쪽으로 이동
            temp.GetComponent<BounceBall>().touchingWithR_Shooter = true;
        }
    }
}