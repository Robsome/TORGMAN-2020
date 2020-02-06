using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NinjaController;

public class ladders : MonoBehaviour
{
    [SerializeField]
    float climbSpeed = 5;
    Rigidbody2D rb;
    public GameObject player;
    public GameObject topOfTheLadder;
    public GameObject bottomOfTheLadder;
    private NinjaController.NinjaController thisController;
    bool isGround;
    float inputAxisY;
    bool isKeyDownUp;
    bool isKeyDownDown;
    Animator anim;

    private void Awake()
    {
        
        
    }
    private void FixedUpdate()
    {
        thisController = player.GetComponent<NinjaController.NinjaController>();
        isGround = thisController.IsOnGround;
        inputAxisY = Input.GetAxisRaw("Vertical");
        isKeyDownUp = inputAxisY > 0.5f;
        isKeyDownDown = inputAxisY < -0.5f;
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (thisController.isClimbing == true && other.CompareTag("Player"))
        {
            if ((isKeyDownUp == true || isKeyDownDown == true))
            {
                rb.position = new Vector2(transform.position.x, rb.position.y);
                //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.velocity = new Vector2(rb.velocity.x, inputAxisY * climbSpeed);
                anim.Play("climbing");
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
            
    }
    
}
