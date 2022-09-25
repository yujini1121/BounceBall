using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Shooter : MonoBehaviour
{
    private bool bounceBall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject temp = GameObject.Find("BounceBall");
            temp.transform.position = new Vector2(transform.position.x - 1.5f, transform.position.y);
            temp.GetComponent<BounceBall>().touchingWithL_Shooter = true;
        }
    }
}