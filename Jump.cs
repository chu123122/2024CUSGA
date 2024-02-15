using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpHigh;
    public float jumpHoldHigh;
    bool isJumping;

    public float jumpTime;
    float jumpTimeCounter;

    public Action Jumping;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
        //Î¯ÍÐ¸³Öµ
        Jumping+= OneJump;
        Jumping += HoldJump;
        Jumping += UpJump;
    }

    private void Update()
    {
        OneJump();
        HoldJump();
        UpJump();
        Debug.Log("isGround:" + IsGroundCheck.isGround);
    }

    void OneJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGroundCheck.isGround)
        {
            rb.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
            isJumping = true;
            print("OneJump");
        }
    }
    void HoldJump()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimeCounter>0 )
        {
            rb.AddForce(Vector2.up * jumpHoldHigh, ForceMode2D.Impulse);
            jumpTimeCounter -= Time.fixedDeltaTime;
        }
    }

    void UpJump()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            jumpTimeCounter = jumpTime;
        }
    }
}
