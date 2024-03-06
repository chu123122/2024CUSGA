using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 测试输出 : MonoBehaviour
{
    void Update()
    {
        
        /*Debug.Log("isAutoTouch:" + CircleAutoGrabCheck.isAutoTouch);
        
        Debug.Log("touchDashCircle:" + GrabCheck.touchDashCircle);
        Debug.Log("!PlayerTouchCircle:" + !PlayerCollisionCheck.PlayerTouchCircle);*/
        /*Debug.Log("PlayerTouchWall:" + PlayerCollisionCheck.PlayerTouchWall);
        Debug.Log("touchWall:" + GrabCheck.touchWall);
        Debug.Log("hitWall:" + RaycastHit.hitWall);
        Debug.Log("GrabCheck.lastColliderWall:" + GrabCheck.lastColliderWall);*/
    }
    private void FixedUpdate()
    {
        Debug.Log("gravityScale:" + Player.PlayerRb.gravityScale);
    }
}
