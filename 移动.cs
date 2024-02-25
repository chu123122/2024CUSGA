using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region 速度参数

    [Tooltip("最大速度")]        
    public float moveSpeed;
    [Tooltip("加速度")]          
    public float acceleration;
    [Tooltip("减速度")]           
    public float decceleration;
    [Tooltip("速度变化程度")]     
    public float velPower;
    #endregion

    private float moveInput;
    private void Update()
    {
        NewMove();
    }
    void NewMove()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - Player.PlayerRb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        Player.PlayerRb.AddForce(movement * Vector2.right, ForceMode2D.Impulse);
    }
}
