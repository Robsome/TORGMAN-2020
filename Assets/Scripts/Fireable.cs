using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireable : MonoBehaviour
{
    public GameObject lemon;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Fire();
    }
    void Fire()
    {
        Instantiate(lemon, transform.position, transform.rotation);
    }
}
