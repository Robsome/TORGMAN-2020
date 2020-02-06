using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomOfLadder : MonoBehaviour
{
    float inputAxisY;
    bool isKeyDownUp;
    bool isKeyDownDown;
    private void Update()
    {
        inputAxisY = Input.GetAxisRaw("Vertical");
        isKeyDownUp = inputAxisY > 0.5f;
        isKeyDownDown = inputAxisY < -0.5f;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            if (isKeyDownUp == true)
            {
                collision.GetComponent<NinjaController.NinjaController>().isClimbing = true;
            }
            if (isKeyDownDown == true && collision.GetComponent<NinjaController.NinjaController>().isClimbing == true)
            {
                collision.GetComponent<Rigidbody2D>().position = new Vector2(collision.GetComponent<Rigidbody2D>().position.x, collision.GetComponent<Rigidbody2D>().position.y + 0.5f);
                collision.GetComponent<NinjaController.NinjaController>().isClimbing = false;
                collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
