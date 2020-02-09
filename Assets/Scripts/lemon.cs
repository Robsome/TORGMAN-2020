using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemon : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enem = collision.gameObject.GetComponent<Enemy>();
        if (enem != null)
        {
            enem.hurt(1);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
