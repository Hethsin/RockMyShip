using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameControl.control.components++;
            Destroy(gameObject);
        }
    }
}