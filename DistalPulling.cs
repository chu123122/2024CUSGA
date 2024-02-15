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
       // }
        

    }
    void DashCheck()
    {
        if (Input.GetMouseButtonDown(0))
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
