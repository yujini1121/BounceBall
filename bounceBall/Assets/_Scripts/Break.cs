using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}