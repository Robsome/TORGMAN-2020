using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotController : MonoBehaviour
{
    public GameObject shootLeft;
    public GameObject shootRight;
    Vector3 theScale;
    void Update()
    {
        float inputAxisX = Input.GetAxisRaw("Horizontal");
        bool isKeyDownLeft = inputAxisX < -0.5f;
        bool isKeyDownRight = inputAxisX > 0.5f;
        theScale = transform.localScale;
        if (isKeyDownLeft == true)
        {
            theScale.x = -1;
            transform.localScale = theScale;
            shootLeft.SetActive(true);
            shootRight.SetActive(false);
        }
        if (isKeyDownRight == true)
        {
            theScale.x = 1;
            transform.localScale = theScale;
            shootRight.SetActive(true);
            shootLeft.SetActive(false);
        }
    }
}
