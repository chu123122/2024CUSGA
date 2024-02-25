using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{
    public static bool PlayerTouchWall;

    private void OnTriggerEnter2D(Collider2D collider)//墙壁进入检测
    {
        if (collider.CompareTag("Wall"))
        {
            PlayerTouchWall = true;
        }
        if (collider.CompareTag("DashCircle"))
        {
            PlayerTouchWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)//墙壁退出检测
    {
        if (collider.CompareTag("Wall"))
        {
            PlayerTouchWall = false;
        }
    }
}
