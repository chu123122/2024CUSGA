using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPulling : MonoBehaviour
{
    
    public float radius = 5f;
  //  public float dashForce;
  //  public float dashForceH;
    public CircleCollider2D circleCollider;

    Transform Player;
    CircleCollider2D playerCollider;
    Rigidbody2D rb;
    Dash dash;
    private bool touchWall;
    private bool touchIronWall;
    private bool hitWall;
    private float orginGravityScale;
    private void Start()
    {
        playerCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<Transform>();
        dash = GetComponent<Dash>();

        circleCollider.radius = radius;
        orginGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        circleCollider.radius = radius;
        RaycastDraw();
        RaycastHitCheck();
        if (touchWall && hitWall)
        {
            dash.DashMouseCheck();
        }
        sideCheck();
        dash.DashMouseAddForce();

       // Debug.Log("side:" + Dash.side);
    }
    void sideCheck()
    {
        if (Dash.side == 0)
        {
            rb.gravityScale = orginGravityScale;
        }
        else if (Dash.side != 0&&hitWall)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }


    void RaycastDraw()//画线
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - (Vector3)Player.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.position, direction, ~(1 << playerCollider.gameObject.layer));

        Debug.DrawLine(Player.position, direction * 1000f, Color.red, 0.01f);
    }

    void RaycastHitCheck()//射线碰撞检测
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - (Vector3)Player.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.position, direction, Mathf.Infinity, ~(1 << playerCollider.gameObject.layer));

        if (hit.collider!=null && hit.collider.CompareTag("Wall"))
        {
            //Debug.Log("Hit Wall: " + hit.collider.gameObject.name);
            hitWall = true;
            
        }
        else
        {
            hitWall = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)//墙壁进入检测
    {
        if (other.CompareTag("Wall"))
        {
            touchWall = true;
        }
        if (other.CompareTag("IronWall"))
        {
            touchWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)//墙壁退出检测
    {
        if (other.CompareTag("Wall"))
        {
            touchWall = false;
        }
        if (other.CompareTag("IronWall"))
        {
            touchWall = false;
        }
    }

    /* void WallDash(Vector3 targetPosition)//冲刺
     {
         Vector2 moveDirection = (targetPosition - Player.position).normalized;
         float xProjection = Vector2.Dot(moveDirection, Vector2.right);
         float yProjection = Vector2.Dot(moveDirection, Vector2.up);
         float angle = Mathf.Atan2(yProjection, xProjection) * Mathf.Rad2Deg;
         //冲刺准备
        // rb.gravityScale = 0;
        // rb.velocity = Vector2.zero;
         //冲刺不同方向
         if (angle >= -22.5f && angle <= 22.5f)
         {
             rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
             print("右");
         }
         else if (angle >= -67.5f && angle <= -22.5f)
         {
             rb.AddForce(Vector2.right * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
             print("右下");
         }
         else if (angle >= -112.5f && angle <= -67.5f)
         {
             rb.AddForce(Vector2.down * dashForceH, ForceMode2D.Impulse);
             print("下");
         }
         else if (angle >= -157.5f && angle <= -112.5f)
         {
             rb.AddForce(Vector2.left * dashForce + Vector2.down * dashForceH, ForceMode2D.Impulse);
             print("左下");
         }
         else if ((angle > 157.5f && angle <= 180) || (angle >= -180 && angle <= -157.5f))
         {
             rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
             print("左");
         }
         else if (angle >= 112.5f && angle <= 157.5f)
         {
             rb.AddForce(Vector2.left * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
             print("左上");
         }
         else if (angle >= 67.5f && angle <= 112.5f)
         {
             rb.AddForce(Vector2.up * dashForceH, ForceMode2D.Impulse);
             print("上");
         }
         else if (angle >= 22.5f && angle <= 67.5f)
         {
             rb.AddForce(Vector2.right * dashForce + Vector2.up * dashForceH, ForceMode2D.Impulse);
             print("右上");
         }
     } */
}

