using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    bool isSheilding = false;

    public void hurt(int damage)
    {
        if (isSheilding == false)
        {
            health = health - damage;
            if (health <= 0)
            {
                kill();
            }
        }
    }
    public void kill()
    {
        Destroy(gameObject);
    }
}
