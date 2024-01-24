using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Star star;

    void Start() 
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            //sington pattern으로 수정할 것
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.GameClear();
        }
    }
}