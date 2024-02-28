using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour
{
    #region 范围判定
    public float radius = 5f;//抓取圆形范围
    public static bool touchWall;
    public static bool touchDashCircle;
    public static  Collider2D lastColliderWall;//最后碰撞物体（？）
    public static Collider2D lastColliderDashCircle;
    private CircleCollider2D circleCollider;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
    }

    private void Update()
    {   
        circleCollider.radius = radius;
    }
    private void OnTriggerEnter2D(Collider2D other)//圆形范围进入判定
    {
        #region 墙壁进入检测
        if (other.CompareTag("Wall"))
        {
            touchWall = true;
            lastColliderWall = other;
        }
        if (other.CompareTag("IronWall"))
        {
            touchWall = true;
        }
        #endregion

        #region 冲刺球进入检测
        if (other.CompareTag("DashCircle"))
        {
            touchDashCircle = true;
            lastColliderDashCircle = other;
        }
        #endregion
    }
    private void OnTriggerExit2D(Collider2D other)//圆形范围离开判定
    
    {
        #region  墙壁退出检测
        if (other.CompareTag("Wall"))
        {
            touchWall = false;
            //lastColliderWall = null;
        }
        if (other.CompareTag("IronWall"))
        {
            touchWall = false;
        }
        #endregion

        #region 冲刺球退出检测
        if (other.CompareTag("DashCircle"))
        {
            touchDashCircle = false;
            lastColliderDashCircle = other;
        }
        #endregion
    }
    #endregion

}
