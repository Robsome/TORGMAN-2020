using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topOfLadder : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    NinjaController.NinjaController theController;
    float inputAxisY;
    bool isKeyDownUp;
    bool isKeyDownDown;

    private void FixedUpdate()
    {
        inputAxisY = Input.GetAxisRaw("Vertical");
        isKeyDownUp = inputAxisY > 0.5f;
        isKeyDownDown = inputAxisY < -0.5f;
        theController = player.GetComponent<NinjaController.NinjaController>();
        if (theController.isClimbing == true)
            platform.SetActive(false);
        if (theController.isClimbing == false)
            platform.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(theController.isClimbing == true && isKeyDownUp == true)
            {
                player.GetComponent<Rigidbody2D>().position = transform.position;
                player.GetComponent<Animator>().Play("climbOn");
                theController.isClimbing = false;
            }
            if (theController.isClimbing == false && isKeyDownDown == true)
            {
                player.GetComponent<Animator>().Play("climbOn");
                player.GetComponent<Rigidbody2D>().position = platform.transform.position;
                theController.isClimbing = true;
            }
        }
    }
}
