using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHorrizontal : MonoBehaviour
{
    public Transform player;
    public float stopLeft;
    public float stopRight;

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= stopLeft && player.position.x <= stopRight)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        if (player.position.x < stopLeft)
        {
            transform.position = new Vector3(stopLeft, transform.position.y, transform.position.z);
        }
        if (player.position.x > stopRight)
        {
            transform.position = new Vector3(stopRight, transform.position.y, transform.position.z);
        }
    }
    
}
