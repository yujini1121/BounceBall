using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarOnOff : MonoBehaviour
{
    public GameObject star;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Down")
        {
            star.SetActive(true);
        }
    }
}