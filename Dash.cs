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
                case 1://右
                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    print("右");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 2://右下
                    rb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("右下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 3://下
                    rb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 4://左下
                    rb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("左下");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 5://左
                    rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    print("左");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 6://左上
                    rb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("左上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 7://上
                    rb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("上");
                    side = 0;
                    dashMount -= 1;
                    break;

                case 8://右上
                    rb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("右上");
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
                case 1://右
                    rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    print("右");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 2://右下
                    rb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("右下");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 3://下
                    rb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("下");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 4://左下
                    rb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
                    print("左下");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 5://左
                    rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
                    print("左");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 6://左上
                    rb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("左上");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 7://上
                    rb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("上");
                    mouseSide = 0;
                    dashButtonMount -= 1;
                    break;

                case 8://右上
                    rb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
                    print("右上");
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
            // 获取鼠标指针在游戏世界中的位置
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 计算玩家需要冲刺的方向
            Vector2 dashDirection = (mousePosition - rb.position).normalized;
            // 投影到X轴和Y轴正方向上
            float xProjection = Vector2.Dot(dashDirection, Vector2.right);
            float yProjection = Vector2.Dot(dashDirection, Vector2.up);

            float angle = Mathf.Atan2(yProjection, xProjection) * Mathf.Rad2Deg;
            // 检查角度是否在指定范围内
            if (angle >= -22.5f && angle <= 22.5f)
            {
                side = 1;//右
                
            }
            else if (angle >= -67.5f && angle <= -22.5f)
            {
                side = 2;//右下
            }
            else if (angle >= -112.5f && angle <= -67.5f)
            {
                side = 3;//下
            }
            else if (angle >= -157.5f && angle <= -112.5f)
            {
                side = 4;//左下
            }
            else if ((angle > 157.5f && angle <= 180) || (angle >= -180 && angle <= -157.5f))
            {
                side = 5;//左
            }
            else if (angle >= 112.5f && angle <= 157.5f)
            {
                side = 6;//左上
            }
            else if (angle >= 67.5f && angle <= 112.5f)
            {
                side = 7;//上
            }
            else if (angle >= 22.5f && angle <= 67.5f)
            {
                side = 8;//右上
            }
        }

    }
    public void DashButtonCheck()
    {
        if (dashButtonMount > 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                mouseSide = 1;//右
            }
            else if (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S))
            {
                mouseSide = 2;//右下
            }
            else if (Input.GetKey(KeyCode.S))
            {
                mouseSide = 3;//下
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                mouseSide = 4;//左下
            }
            else if (Input.GetKey(KeyCode.A))
            {
                mouseSide = 5;//左
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                mouseSide = 6;//左上
            }
            else if (Input.GetKey(KeyCode.W))
            {
                mouseSide = 7;//上
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                mouseSide = 8;//右上
            }

        }
    }
}
