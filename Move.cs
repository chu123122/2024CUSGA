using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour
{
    public float moveSpeed;//����ٶ�
    public float acceleration;//���ٶ�
    public float decceleration;//���ٶ�
    public float velPower;//�ٶȱ仯�̶�
    float moveInput;

    Rigidbody2D rb;

    public Action Walk;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Walk += NewMove;
    }
    private void Update()
    {
        NewMove();


    }
    void NewMove()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb.AddForce(movement * Vector2.right, ForceMode2D.Impulse);
    }
}
