using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistalPulling: MonoBehaviour
{
    Rigidbody2D rb;
    int side = 0;
    public float dashForce;
    public float dashForceH;
    float orginGravityScale;
    int dashMount = 1;

    float rotationAngle = 22.5f;

    LoadCheck loadcheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orginGravityScale = rb.gravityScale;
    }

    private void Update()
    {
      //  if (loadcheck.isLoad)
      //  {
      //     dashMount = 1;
      //  }
        DashCheck();
        DashEffect();
        DashAddForce();
      //  Debug.Log("side:" + side);
      //  Debug.Log("loadcheck:" + loadcheck.isLoad);

    }

    void DashEffect()
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
    void DashAddForce()
    {
       // if (dashMount > 0)
       // {
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
       // }
        

    }
    void DashCheck()
    {
        if (Input.GetMouseButtonDown(0))
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
            /* if (dashDirection.x > 0&& dashDirection.y>0)
             {
                 if (dashDirection.x > dashDirection.y)
                     side = 1;
                 else
                     side = 2;
             }
             else if(dashDirection.x > 0 && dashDirection.y< 0)
             {
                 if (dashDirection.x > Mathf.Abs(dashDirection.y))
                     side = 3;
                 else
                     side = 4;
             }
             else if (dashDirection.x < 0 && dashDirection.y < 0)
             {
                 if (Mathf.Abs(dashDirection.x) > Mathf.Abs(dashDirection.y))
                     side = 5;
                 else
                     side = 6;
             }
             else if (dashDirection.x < 0 && dashDirection.y > 0)
             {
                 if (Mathf.Abs(dashDirection.x) > Mathf.Abs(dashDirection.y))
                     side = 7;
                 else
                     side = 8;
             }*/
         //   print("Mouse0");
        }

    }
}
