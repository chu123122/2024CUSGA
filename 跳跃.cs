using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    #region 跳跃参数

    [Tooltip("跳跃高度")]
    public float jumpHigh;
    [Tooltip("长按时增加的跳跃高度")]
    public float jumpHoldHigh;
    [Tooltip("长按跳跃作用的时间")]
    public float jumpTime;
    #endregion

    private bool isJumping;
    private float jumpTimeCounter;

    private void Start()
    {
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        OneJump();
        HoldJump();
        UpJump();
        //Debug.Log("isGround:" + IsGroundCheck.isGround);
    }

    void OneJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGroundCheck.isGround)
        {
            Player.PlayerRb.AddForce(Vector2.up * jumpHigh, ForceMode2D.Impulse);
            isJumping = true;
            // print("OneJump");
        }
    }
    void HoldJump()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimeCounter > 0)
        {
            Player.PlayerRb.AddForce(Vector2.up * jumpHoldHigh, ForceMode2D.Impulse);
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
