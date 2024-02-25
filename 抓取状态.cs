using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grab : MonoBehaviour
{
    public static int grabMount = 1;
    public static bool oneTouchWall = false;
    public float grabForce;
    private Vector3 direction;
    public void grabCheck()
    {
            // 获取鼠标在屏幕上的位置
            Vector3 mousePosition = Input.mousePosition;
            // 将鼠标位置转换为世界坐标
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));

            // 计算朝向目标位置的方向向量
            direction = (targetPosition - Player.PlayerTf.position).normalized;
            
            Debug.Log("grabMount:" + grabMount);
    }

    public void GrabAddforce()
    {
        
        if (Input.GetMouseButtonDown(0) && !PlayerCollisionCheck.PlayerTouchWall&& GrabCheck.touchWall&& RaycastHit.hitWall)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            Player.PlayerRb.AddForce(direction * grabForce*100, ForceMode2D.Force);
            grabMount = 0;
        }
        else if (PlayerCollisionCheck.PlayerTouchWall&& !oneTouchWall)
        {
            Player.PlayerRb.velocity = Vector2.zero;
            oneTouchWall = true;
        }
    }
    public void GrabEffect()
    {
        if (grabMount == 0)
        {
            Player.PlayerRb.gravityScale = Player.orginGravityScale;
        }
    }
}
