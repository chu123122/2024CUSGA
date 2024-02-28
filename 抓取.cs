using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    #region 抓取参数
    [Tooltip("抓取速度")]
    public float grabForce;
    #endregion

    public static int grabMount = 1;
    public static bool oneTouchWall = false;
    public static bool oneTouchDashCircle = false;
    public static Vector3 direction;
    private bool hadGrab = false;
    private void Update()
    {
        grabCheck();
        GrabEffect();
        GrabAddforce();
    }
    public void grabCheck()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        direction = (targetPosition - Player.PlayerTf.position).normalized;
    }

    public void GrabAddforce()
    {

        if (hadGrab)
        {
            GetComponent<Move>().enabled = true;
            hadGrab = false;
        }
        if (Input.GetMouseButtonDown(0) && !PlayerCollisionCheck.PlayerTouchWall && GrabCheck.touchWall && RaycastHit.hitWall)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            GetComponent<Move>().enabled = false;
            Player.PlayerRb.AddForce(direction * grabForce * 100, ForceMode2D.Force);
            grabMount = 0;

            hadGrab = true;
        }
        else if (PlayerCollisionCheck.PlayerTouchWall && !oneTouchWall)
        {
            GetComponent<Move>().enabled = true;
            Player.PlayerRb.velocity = Vector2.zero;
            oneTouchWall = true;
        }

        if(Input.GetMouseButtonDown(0) && !PlayerCollisionCheck.PlayerTouchCircle && GrabCheck.touchDashCircle && RaycastHit.hitDashCircle)
        {
            Player.PlayerRb.gravityScale = 0;
            Player.PlayerRb.velocity = Vector2.zero;
            GetComponent<Move>().enabled = false;
            Player.PlayerRb.AddForce(direction * grabForce * 100, ForceMode2D.Force);
            grabMount = 0;

            hadGrab = true;
        }
        else if (PlayerCollisionCheck.PlayerTouchCircle && !oneTouchDashCircle)
        {
            GetComponent<Move>().enabled = true;
            Player.PlayerRb.velocity = Vector2.zero;
            oneTouchDashCircle = true;
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
