using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.localScale *= 1.1f;
        other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 0.2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.localScale *= 1.2f;
    }
}
