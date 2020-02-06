using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    public float speed;
    public float climbSpeed;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    public LayerMask whatIsDown;
    private bool isClimbing;
    public float gravity;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private SpriteRenderer theSprite;
    Collider ladderCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        theSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.freezeRotation = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        bool isKeyDownLeft = inputHorizontal < -0.5f;
        bool isKeyDownRight = inputHorizontal > 0.5f;
        bool isKeyDownUp = inputVertical > 0.5f;
        bool isKeyDownDown = inputVertical < -0.5f;



        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        RaycastHit2D isGround = Physics2D.Raycast(transform.position, Vector2.down, 1, whatIsDown);

        if (isClimbing == false || hitInfo.collider == null || isGround.collider != null)
            rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        if (hitInfo.collider != null)
        {
            if (isKeyDownUp == true || isKeyDownDown == true)
            {
                Debug.Log("isTrue");
                isClimbing = true;
            }
            
        }
        else if (isKeyDownLeft == true || isKeyDownRight == true || isGround.collider != null)
        {
           
                isClimbing = false;
            Debug.Log("isFalse");
        }
        if (isClimbing == true && hitInfo.collider != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = new Vector2(transform.position.x, inputVertical * climbSpeed);
            rb.gravityScale = 0;
            rb.position = new Vector3(ladderCollider.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = gravity;
        }
        if (Input.GetButtonDown("Jump") && isGround.collider != null)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter (Collider collision)
    {
        if (isClimbing == true)
        {
            collision = ladderCollider;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        ladderCollider = null;
    }
}
