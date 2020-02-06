using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemon2 : MonoBehaviour
{
    public float speed = -20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
