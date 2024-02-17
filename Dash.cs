using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash: MonoBehaviour
{
    public Rigidbody2D rb;
    [HideInInspector] public static int side = 0;
    [HideInInspector] public static int mouseSide = 0;
    public float dashForce;
    public float dashForceH;
    private float orginGravityScale;
    
    public static int dashMount = 1;
    public static int dashButtonMount = 0;

    void Start()
    {
        orginGravityScale = rb.gravityScale;
    }
    public void DashEffect()
    {
        if (side == 0)
        {
            rb.gravityScale = orginGravityScale;
        }
        else if(side!=0)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }
    public void DashMouseAddForce()
    {
        if (dashMount > 0)
        {
            switch (side)
            {
                case 1://��
                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    print("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 2://����
                    rb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 3://��
                    rb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 4://����
                    rb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 5://��
                    rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    print("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 6://����
                    rb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 7://��
                    rb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("��");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 8://����
                    rb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    side = 0;
                    dashMount -= 1;
                    break;
            }
        }
        

    }

    public void DashButtonAddForce()
    {
        if (dashButtonMount > 0)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            switch (mouseSide)
            {
                case 1://��
                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    print("��");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 2://����
                    rb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 3://��
                    rb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("��");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 4://����
                    rb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 5://��
                    rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    print("��");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 6://����
                    rb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 7://��
                    rb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("��");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 8://����
                    rb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("����");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;
            }
        }
    }
    public  void DashMouseCheck()
    {
        if (Input.GetMouseButtonDown(0)&&dashMount>0)
        {
            // ��ȡ���ָ������Ϸ�����е�λ��
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���������Ҫ��̵ķ���
            Vector2 dashDirection = (mousePosition - rb.position).normalized;
            // ͶӰ��X���Y����������
            float xProjection = Vector2.Dot(dashDirection, Vector2.right);
            float yProjection = Vector2.Dot(dashDirection, Vector2.up);

            float angle = Mathf.Atan2(yProjection, xProjection) * Mathf.Rad2Deg;
            // ���Ƕ��Ƿ���ָ����Χ��
            if (angle >= -22.5f && angle <= 22.5f)
            {
                side = 1;//��
                
            }
            else if (angle >= -67.5f && angle <= -22.5f)
            {
                side = 2;//����
            }
            else if (angle >= -112.5f && angle <= -67.5f)
            {
                side = 3;//��
            }
            else if (angle >= -157.5f && angle <= -112.5f)
            {
                side = 4;//����
            }
            else if ((angle > 157.5f && angle <= 180) || (angle >= -180 && angle <= -157.5f))
            {
                side = 5;//��
            }
            else if (angle >= 112.5f && angle <= 157.5f)
            {
                side = 6;//����
            }
            else if (angle >= 67.5f && angle <= 112.5f)
            {
                side = 7;//��
            }
            else if (angle >= 22.5f && angle <= 67.5f)
            {
                side = 8;//����
            }
        }

    }
    public void DashButtonCheck()
    {
        if (dashButtonMount > 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                mouseSide = 1;//��
            }
            else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S))
            {
                mouseSide = 2;//����
            }
            else if (Input.GetKey(KeyCode.S))
            {
                mouseSide = 3;//��
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                mouseSide = 4;//����
            }
            else if (Input.GetKey(KeyCode.A))
            {
                mouseSide = 5;//��
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                mouseSide = 6;//����
            }
            else if (Input.GetKey(KeyCode.W))
            {
                mouseSide = 7;//��
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                mouseSide = 8;//����
            }

        }
    }
}
