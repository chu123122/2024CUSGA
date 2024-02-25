using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RaycastHit : MonoBehaviour   
{
    public static bool hitWall;
    public static bool hitDashCircle;
    
    private void Update()
    {
        RaycastDraw();
        RaycastHitCheck();
        
    }
    void RaycastDraw()//画线
    {
        #region 生成线

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - Player.PlayerTf.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.PlayerTf.position, direction, ~(1 << Player.PlayerCo.gameObject.layer));
        #endregion

        Debug.DrawLine(Player.PlayerTf.position, direction * 1000f, Color.red, 0.001f);
    }

    void RaycastHitCheck()//射线碰撞检测
    {
        #region 生成线

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = (targetPosition - (Vector3)Player.PlayerTf.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(Player.PlayerTf.position, direction, Mathf.Infinity, ~(1 << Player.PlayerCo.gameObject.layer));
        #endregion

        if (hit.collider != null && hit.collider == GrabCheck.lastColliderWall)//墙壁
            hitWall = true;
        else
            hitWall = false;


        if (hit.collider != null && hit.collider.CompareTag("DashCircle"))//冲刺球
            hitDashCircle = true;
        else
            hitDashCircle = false;

        if (hit.collider != null)
            Debug.Log("RaycastHit" + hit.collider.name);
        else
            print("null");
    }
}
